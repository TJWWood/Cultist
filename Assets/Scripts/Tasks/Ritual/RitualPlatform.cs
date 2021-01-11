using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//TODO try make trail come from player after initial totem hit and not platform
//TODO Fix trail being added to player twice - and in turn removed twice
public class RitualPlatform : MonoBehaviour
{
    private float ritualProgressCount;
    public float ritualTarget;
    private bool isRitualComplete;
    bool skillPointAdded;
    public GameObject trail;
    public GameObject cultist1;
    public GameObject cultist2;
    public GameObject cultist3;

    private GameObject loadedTrail;
    private Transform totem;
    private Vector3 target;

    public TextMeshProUGUI progressText;

    public int cultistCounter;
    private float negativeRitualSpeedWithoutPlayer;

    bool firstTimeEntering;
    bool firstTimeLeaving;

    // Start is called before the first frame update
    void Start()
    {
        ritualProgressCount = 0;
        totem = transform.parent.parent.GetChild(0).transform;
        target = new Vector3(totem.position.x, totem.position.y + 2f, totem.position.z);

        isRitualComplete = false;
        progressText.gameObject.SetActive(false);
        firstTimeEntering = true;
        firstTimeLeaving = true;
    }

    void Update()
    {
        if(!isRitualComplete)
        {
            //TODO add check for cultists dying and effectively change counter

            if(cultistCounter == 1)
            {
                negativeRitualSpeedWithoutPlayer = 100f;
            }
            else if(cultistCounter == 2)
            {
                negativeRitualSpeedWithoutPlayer = 75f;
            }
            else if(cultistCounter == 3)
            {
                negativeRitualSpeedWithoutPlayer = 50f;
            }

            ritualProgressCount += Time.deltaTime / negativeRitualSpeedWithoutPlayer;
            //Debug.Log("AUTO RITUAL: " + ritualProgressCount);
        }
        else
        {
            cultist1.GetComponentInChildren<TrailRenderer>().emitting = false;
            cultist2.GetComponentInChildren<TrailRenderer>().emitting = false;
            cultist3.GetComponentInChildren<TrailRenderer>().emitting = false;
        }

        progressText.text = "Ritual Progress: " + System.Math.Round(ritualProgressCount, 2) + " (" + System.Math.Round((ritualProgressCount / ritualTarget) * 100, 2) + "%)";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(firstTimeEntering)
        {
            other.gameObject.AddComponent<FirstTimeOnRitual>();
            firstTimeEntering = false;
        }

        loadedTrail = Instantiate(trail, Camera.main.transform, false);
        loadedTrail.transform.SetAsFirstSibling();
        loadedTrail.transform.localPosition = new Vector3(0f, Camera.main.transform.position.y, 0f);

        loadedTrail.GetComponent<TrailRenderer>().enabled = false;

        progressText.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("In ritual zone");
        
        if(Input.GetKey(KeyCode.E))
        {
            loadedTrail.GetComponent<TrailRenderer>().enabled = true;
            if (ritualProgressCount >= ritualTarget)
            {
                ritualProgressCount = ritualTarget;
                isRitualComplete = true;
                if(!skillPointAdded)
                {
                    other.gameObject.GetComponent<PlayerStats>().playerSkillPoints++;
                    skillPointAdded = true;
                }
                //Debug.Log("RITUAL COMPLETE");
            }
            else
            {
                //Debug.Log("Timer counting: " + ritualProgressCount);
                
                loadedTrail.transform.position = Vector3.MoveTowards(loadedTrail.transform.position, target, 5f * Time.deltaTime);
                if (Vector3.Distance(loadedTrail.transform.position, target) <= 0.01f)
                {
                    loadedTrail.transform.position = transform.position;
                }
                ritualProgressCount += Time.deltaTime;
            }
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out FirstTimeOnRitual ftor))
        {
            
        }
        if(firstTimeLeaving)
        {
            other.gameObject.AddComponent<FirstTimeLeavingRitual>();
            firstTimeLeaving = false;
        }

        progressText.gameObject.SetActive(false);
        Destroy(Camera.main.transform.GetChild(0).gameObject);
    }
}
