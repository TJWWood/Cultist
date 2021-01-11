using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkObjects : MonoBehaviour
{
    public GameObject water;
    public GameObject alcohol;
    public GameObject milk;

    public static Dictionary<string, GameObject> drinkObjDict = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        drinkObjDict.Add("Water", water);
        drinkObjDict.Add("Alcohol", alcohol);
        drinkObjDict.Add("Milk", milk);
    }
}
