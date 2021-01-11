using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryManager;

public class PickupObject : MonoBehaviour
{
    public string itemTypeOut;
    public int itemIDOut;
    public string itemNameOut;
    public ItemData itemData;
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, 5f))
            {
                if (hit.transform.CompareTag("Food") || hit.transform.CompareTag("Drink") || hit.transform.CompareTag("Med"))
                { 
                    switch(hit.transform.tag)
                    {
                        case "Food":
                            //TODO possibly change to just get gameobject item name to save resources
                            itemNameOut = hit.transform.parent.name;

                            if (FoodStorage.TryGetValue(itemNameOut, out itemData) && weightLimit >= itemData.GetWeight())
                            {
                                itemData.AddQuantity(1);
                                FoodStorage[itemNameOut] = itemData;
                                Debug.Log(itemNameOut + " " + itemData.ToString());
                                weightLimit -= itemData.GetWeight();
                                Destroy(hit.transform.gameObject);
                            }
                            break;
                        case "Drink":
                            itemNameOut = hit.transform.parent.name;
  
                            if (DrinkStorage.TryGetValue(itemNameOut, out itemData) && weightLimit >= itemData.GetWeight())
                            {
                                itemData.AddQuantity(1);
                                DrinkStorage[itemNameOut] = itemData;
                                Debug.Log(itemNameOut + " " + itemData.ToString());
                                weightLimit -= itemData.GetWeight();
                            }
                            break;
                        case "Med":
                            itemNameOut = hit.transform.parent.name;

                            if (MedStorage.TryGetValue(itemNameOut, out itemData) && weightLimit >= itemData.GetWeight())
                            {
                                itemData.AddQuantity(1);
                                MedStorage[itemNameOut] = itemData;
                                Debug.Log(itemNameOut + " " + itemData.ToString());
                                weightLimit -= itemData.GetWeight();
                            }
                            break;
                    }
                }
            }
        }
    } 
}
