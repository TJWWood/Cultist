using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    private bool hasDrink;
    private float hunger;
    private float drinkValue;
    private float thirstQuenchedTimer;
    private bool thirstQuenched;
    // Start is called before the first frame update
    void Start()
    {
        hunger = gameObject.GetComponent<PlayerStats>().playerHunger;
        hasDrink = true;
        drinkValue = 2f;
        thirstQuenchedTimer = 10f;
        thirstQuenched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDrink)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Drinks");
                if (hunger + drinkValue >= 100f)
                {
                    gameObject.GetComponent<PlayerStats>().playerThirst = 100f;
                    gameObject.GetComponent<DrainPlayerStats>().thirstDrainRate = 0f;
                    thirstQuenched = true;
                }
                else
                {
                    gameObject.GetComponent<PlayerStats>().playerThirst += drinkValue;
                }
            }
        }

        if (thirstQuenched)
        {
            thirstQuenchedTimer -= Time.deltaTime;
            Debug.Log(thirstQuenchedTimer);
            if (thirstQuenchedTimer <= 0)
            {
                gameObject.GetComponent<DrainPlayerStats>().thirstDrainRate = 0.05f;
                thirstQuenched = false;
            }
        }
    }
}
