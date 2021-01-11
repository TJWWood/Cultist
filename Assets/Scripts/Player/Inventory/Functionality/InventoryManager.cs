using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static float weightLimit;

    public static Dictionary<string, ItemData> FoodStorage;
    public static Dictionary<string, ItemData> DrinkStorage;
    public static Dictionary<string, ItemData> MedStorage;

    // Start is called before the first frame update
    void Start()
    {
        FoodStorage = new Dictionary<string, ItemData>();
        DrinkStorage = new Dictionary<string, ItemData>();
        MedStorage = new Dictionary<string, ItemData>();
        weightLimit = 50;

        var linesOfFoodsFile = System.IO.File.ReadAllLines(@"C:\Users\Thomas Wood\Desktop\Food.txt");

        foreach (var line in linesOfFoodsFile)
        {
            var output = line.Split(',');

            ItemData tempItemData = new ItemData();
            tempItemData.AddQuantity(int.Parse(output[1]));
            tempItemData.AddWeight(float.Parse(output[2]));
            tempItemData.AddValue(float.Parse(output[3]));

            FoodStorage.Add(output[0].ToString(), tempItemData);

            Debug.Log(output[0] + " " + output[1] + " " + output[2] + " " + output[3]);
        }

        var linesOfDrinksFile = System.IO.File.ReadAllLines(@"C:\Users\Thomas Wood\Desktop\Drinks.txt");

        foreach (var line in linesOfDrinksFile)
        {
            var output = line.Split(',');

            ItemData tempItemData = new ItemData();
            tempItemData.AddQuantity(int.Parse(output[1]));
            tempItemData.AddWeight(float.Parse(output[2]));
            tempItemData.AddValue(float.Parse(output[3]));

            DrinkStorage.Add(output[0].ToString(), tempItemData);

            Debug.Log(output[0] + " " + output[1] + " " + output[2] + " " + output[3]);
        }

        var linesOfMedsFile = System.IO.File.ReadAllLines(@"C:\Users\Thomas Wood\Desktop\Meds.txt");

        foreach (var line in linesOfMedsFile)
        {
            var output = line.Split(',');

            ItemData tempItemData = new ItemData();
            tempItemData.AddQuantity(int.Parse(output[1]));
            tempItemData.AddWeight(float.Parse(output[2]));
            tempItemData.AddValue(float.Parse(output[3]));

            MedStorage.Add(output[0].ToString(), tempItemData);

            Debug.Log(output[0] + " " + output[1] + " " + output[2] + " " + output[3]);
        }
    }

    public struct ItemData
    {
        int quantity;
        float weight;
        float value;

        public void AddQuantity(int quantityToAdd)
        {
            quantity += quantityToAdd;
        }

        public void AddWeight(float weightToAdd)
        {
            weight += weightToAdd;
        }

        public void AddValue(float valueToAdd)
        {
            value += valueToAdd;
        }

        public float GetWeight()
        {
            return weight;
        }

        public float GetValue()
        {
            return value;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void LowerQuantity()
        {
            quantity--;
        }

        public override string ToString() => "Quantity: " + quantity + "Weight: " + weight + " Value: " + value;
    }
}
