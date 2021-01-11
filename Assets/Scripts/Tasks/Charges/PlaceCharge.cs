using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryManager;

public class PlaceCharge : MonoBehaviour
{
    public Material activeMat;
    ItemData itemData;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.GetChild(0).GetComponent<Renderer>().material = activeMat;
            transform.GetChild(1).GetComponent<Renderer>().material = activeMat;
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
