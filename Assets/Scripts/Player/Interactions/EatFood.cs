using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static InventoryManager;

public class EatFood : MonoBehaviour
{
    private float hunger;
    public float foodValue;
    public float weight;
    public string foodName;
    // Start is called before the first frame update
    void Start()
    {
        hunger = gameObject.GetComponent<PlayerStats>().playerHunger;
        Debug.Log("Eats food");
        if (hunger + foodValue >= 100f)
        {
            gameObject.GetComponent<PlayerStats>().playerHunger = 100f;
            gameObject.GetComponent<DrainPlayerStats>().hungerDrainRate = 0f;
            gameObject.GetComponent<PlayerStats>().playerWellFed = true;

            if (gameObject.GetComponent<WellFed>() == null)
            {
                gameObject.AddComponent<WellFed>();
            }
        }
        else
        {
            gameObject.GetComponent<PlayerStats>().playerHunger += foodValue;
        }
        FoodStorage[foodName].LowerQuantity();
        weightLimit -= weight;

        Destroy(this);
    }
}
