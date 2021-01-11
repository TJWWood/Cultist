using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstTimeLeavingRitual : MonoBehaviour
{
    GameObject tutorialText;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        tutorialText = GameObject.Find("Tutorial Canvas");
        timer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialText.transform.GetChild(0).gameObject.activeSelf == false)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                tutorialText.transform.GetChild(1).gameObject.SetActive(true);
                //tutorialText.SetActive(true);
            }
            else
            {
                tutorialText.transform.GetChild(1).gameObject.SetActive(false);
                Destroy(gameObject.GetComponent<FirstTimeLeavingRitual>());
            }
        }
    }
}
