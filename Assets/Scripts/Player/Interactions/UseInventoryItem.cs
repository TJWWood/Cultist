using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UseInventoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    //private EatFood eatFood;
    public GameObject player;
    void Start()
    {
        //eatFood = player.GetComponent<EatFood>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eat(string name, float value, float weight)
    {
        //player.AddComponent<EatFood>().Eat(name, value, weight);
        Debug.Log("USED ITEM: " + name);
    }

    public void Drink(string name)
    {

    }

    public void UseMed(string name)
    {

    }
}
