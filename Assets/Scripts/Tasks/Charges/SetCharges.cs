using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharges : MonoBehaviour
{
    public GameObject charge1;
    public GameObject charge2;
    public GameObject charge3;
    public GameObject charge4;
    bool skillPointAdded;
    GameObject player;

    public GameObject explosion;
    public GameObject smoke;
    public GameObject fire;

    bool chargesSet;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (!chargesSet)
        {
            if (charge1.transform.GetChild(2).gameObject.activeSelf && charge2.transform.GetChild(2).gameObject.activeSelf && charge3.transform.GetChild(2).gameObject.activeSelf && charge4.transform.GetChild(2).gameObject.activeSelf)
            {
                chargesSet = true;
                //Debug.Log("CHARGES SET");
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Charges Detonated");
                Destroy(charge1);
                Destroy(charge2);
                Destroy(charge3);
                Destroy(charge4);
                explosion.gameObject.SetActive(true);
                smoke.gameObject.SetActive(true);
                fire.gameObject.SetActive(true);

                //Destroy(relatedBuilding);
                //transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                if (!skillPointAdded)
                {
                    player.GetComponent<PlayerStats>().playerSkillPoints++;
                    skillPointAdded = true;
                }
            }
        }
    }


}
