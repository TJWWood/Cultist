using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainPlayerStats : MonoBehaviour
{
    public float healthDrainRate;
    public float hungerDrainRate;
    public float thirstDrainRate;
    public float sanityDrainRate;
    public float staminaDrainRate;
    public float fatigueDrainRate;

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<PlayerStats>().playerHealth -= 0.05 * Time.deltaTime;
        gameObject.GetComponent<PlayerStats>().playerHunger -= hungerDrainRate * Time.deltaTime;
        gameObject.GetComponent<PlayerStats>().playerThirst -= thirstDrainRate * Time.deltaTime;
        gameObject.GetComponent<PlayerStats>().playerSanity -= sanityDrainRate * Time.deltaTime;
        gameObject.GetComponent<PlayerStats>().playerStamina -= staminaDrainRate * Time.deltaTime;
        gameObject.GetComponent<PlayerStats>().playerFatigue -= fatigueDrainRate * Time.deltaTime;
    }
}
