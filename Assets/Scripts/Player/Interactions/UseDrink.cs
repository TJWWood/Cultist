using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryManager;

public class UseDrink : MonoBehaviour
{
    private float thirst;
    public float drinkValue;
    public float weight;
    public string drinkName;
    // Start is called before the first frame update
    void Start()
    {
        thirst = gameObject.GetComponent<PlayerStats>().playerThirst;
        Debug.Log("Drinks drink");
        if (thirst + drinkValue >= 100f)
        {
            gameObject.GetComponent<PlayerStats>().playerThirst = 100f;
            gameObject.GetComponent<DrainPlayerStats>().thirstDrainRate = 0f;
            gameObject.GetComponent<PlayerStats>().playerWellHydrated = true;

            if (gameObject.GetComponent<WellHydrated>() == null)
            {
                gameObject.AddComponent<WellHydrated>();
            }
        }
        else
        {
            gameObject.GetComponent<PlayerStats>().playerThirst += drinkValue;
        }
        DrinkStorage[drinkName].LowerQuantity();
        weightLimit -= weight;

        Destroy(this);
    }
}
