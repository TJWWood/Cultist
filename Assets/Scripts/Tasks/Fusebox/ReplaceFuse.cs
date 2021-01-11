using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryManager;

public class ReplaceFuse : MonoBehaviour
{
    public GameObject rightFuse;
    ItemData itemData;
    GameObject player;
    bool skillPointAdded;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Stole Fuse");
            rightFuse.SetActive(false);
            if (!skillPointAdded)
            {
                player.GetComponent<PlayerStats>().playerSkillPoints++;
                skillPointAdded = true;
            }
        } 
    }
}
