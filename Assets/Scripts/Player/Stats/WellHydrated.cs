using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellHydrated : MonoBehaviour
{
    private float wellHydratedTimer;

    // Start is called before the first frame update
    void Start()
    {
        wellHydratedTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        wellHydratedTimer -= Time.deltaTime;
        //Debug.Log(fullStomachTimer);
        if (wellHydratedTimer <= 0)
        {
            gameObject.GetComponent<DrainPlayerStats>().thirstDrainRate = 0.05f;
            gameObject.GetComponent<PlayerStats>().playerWellHydrated = false;
            Destroy(this);
        }
    }
}
