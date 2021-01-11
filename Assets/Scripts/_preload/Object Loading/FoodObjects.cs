using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObjects : MonoBehaviour
{
    public GameObject banana;
    public GameObject apple;
    public GameObject cake;

    public static Dictionary<string, GameObject> foodObjDict = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foodObjDict.Add("Banana", banana);
        foodObjDict.Add("Apple", apple);
        foodObjDict.Add("Cake", cake);
    }

}
