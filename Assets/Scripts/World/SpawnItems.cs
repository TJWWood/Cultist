using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryManager;

public class SpawnItems : MonoBehaviour
{
    public int itemsToSpawn;

    //to replace with random item choice logic
    GameObject emptyItemDrop;

    // Start is called before the first frame update
    void Start()
    {
        float boxX = gameObject.GetComponent<BoxCollider>().size.x;
        float boxY = gameObject.GetComponent<BoxCollider>().size.y;
        float boxZ = gameObject.GetComponent<BoxCollider>().size.z;
        Vector3 boxCenter = transform.position;

        for (int i = 0; i < itemsToSpawn; i++)
        {
            emptyItemDrop = new GameObject();
            float spawnX = Random.Range(boxCenter.x - (boxX / 2), boxCenter.x + (boxX / 2));
            float spawnY = Random.Range(boxCenter.y - (boxY / 2), boxCenter.y + (boxY / 2));
            float spawnZ = Random.Range(boxCenter.z - (boxZ / 2), boxCenter.z + (boxZ / 2));

            Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);

            int itemTypeChoice = Random.Range(0, 3);
            switch(itemTypeChoice)
            {
                case 0:
                    emptyItemDrop.AddComponent<SetFoodObject>();
                    break;       
                case 1:
                    emptyItemDrop.AddComponent<SetDrinkObject>();
                    break;
                case 2:
                    emptyItemDrop.AddComponent<SetMedObject>();
                    break;
                default:
                    break;
            }
            emptyItemDrop.transform.position = spawnPos;
            emptyItemDrop.transform.parent = transform;
        }
    }
}
