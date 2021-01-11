using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Items;
using Random = UnityEngine.Random;
using static MedObjects;

public class SetMedObject : MonoBehaviour
{
    public string itemName;
    public bool isRandomSelection = true;

    private void Awake()
    {
        gameObject.tag = "Med";

        if (isRandomSelection)
        {
            int randChoice = Random.Range(0, Enum.GetNames(typeof(Meds)).Length);
            itemName = ((Meds)randChoice).ToString();
            gameObject.name = itemName;

            GameObject item;
            if (medObjDict.TryGetValue(itemName, out item))
            {
                item.gameObject.tag = "Med";
                item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                Instantiate(item, transform.position, transform.rotation, transform);
            }
        }
    }
}

