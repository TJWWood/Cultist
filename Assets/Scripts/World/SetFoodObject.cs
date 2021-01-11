using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Items;
using Random = UnityEngine.Random;
using static FoodObjects;

public class SetFoodObject : MonoBehaviour
{
    public string itemName;
    public bool isRandomSelection = true;
    
    private void Awake()
    {
        gameObject.tag = "Food";
        if (isRandomSelection)
        {
            int randChoice = Random.Range(0, Enum.GetNames(typeof(Foods)).Length);
            itemName = ((Foods)randChoice).ToString();
            gameObject.name = itemName;

            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //gameObject.AddComponent<MeshFilter>().sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;
            //gameObject.AddComponent<MeshRenderer>().sharedMaterial = go.GetComponent<MeshRenderer>().sharedMaterial;
            //gameObject.AddComponent<Rigidbody>();
            //gameObject.AddComponent<BoxCollider>();
            //Destroy(go);

            GameObject item;
            if(foodObjDict.TryGetValue(itemName, out item))
            {
                item.gameObject.tag = "Food";
                item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                Instantiate(item, transform.position, transform.rotation, transform);
            }

        }
    }
}
