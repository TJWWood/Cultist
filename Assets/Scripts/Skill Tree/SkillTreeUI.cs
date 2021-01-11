using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{ 
    public GameObject skillTreeUI;
    bool skillTreeUIOpen;
    public GameObject skillPointsText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !skillTreeUIOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            skillTreeUIOpen = true;
            for (int i = 0; i < skillTreeUI.transform.childCount; i++)
            {
                Transform currentChild = skillTreeUI.transform.GetChild(i);
                if(currentChild.CompareTag("ShowSkillUI"))
                {
                    currentChild.gameObject.SetActive(true);
                }
                else if (currentChild.CompareTag("HideSkillUI"))
                {
                    continue;
                }

                if (currentChild.CompareTag("ShowAllSkillUI"))
                {
                    currentChild.gameObject.SetActive(true);
                }
            }
            skillPointsText.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && skillTreeUIOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            skillTreeUIOpen = false;
            for (int i = 0; i < skillTreeUI.transform.childCount; i++)
            {
                Transform currentChild = skillTreeUI.transform.GetChild(i);
                currentChild.gameObject.SetActive(false);
                Debug.Log("Closed skill tree UI");
            }
            skillPointsText.SetActive(false);
        }
    }
}
