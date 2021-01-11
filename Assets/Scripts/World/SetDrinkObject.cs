using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Items;
using Random = UnityEngine.Random;
using static DrinkObjects;

public class SetDrinkObject : MonoBehaviour
{
    public string itemName;
    public bool isRandomSelection = true;

    private void Awake()
    {
        gameObject.tag = "Drink";
        if (isRandomSelection)
        {
            int randChoice = Random.Range(0, Enum.GetNames(typeof(Drinks)).Length);
            itemName = ((Drinks)randChoice).ToString();
            gameObject.name = itemName;

            GameObject item;
            if(drinkObjDict.TryGetValue(itemName, out item))
            {
                item.gameObject.tag = "Drink";
                item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                Instantiate(item, transform.position, transform.rotation, transform);
            }
        }
    }
}


