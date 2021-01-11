using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStats;

public class WellFed : MonoBehaviour
{
    private float wellFedTimer;

    // Start is called before the first frame update
    void Start()
    {
        wellFedTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        wellFedTimer -= Time.deltaTime;
        //Debug.Log(fullStomachTimer);
        if (wellFedTimer <= 0)
        {
            gameObject.GetComponent<DrainPlayerStats>().hungerDrainRate = 0.05f;
            gameObject.GetComponent<PlayerStats>().playerWellFed = false;
            Destroy(this);
        } 
    }
}
