using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkillUI : MonoBehaviour
{
    public GameObject skillToUnlock;
    public GameObject skillUnlockedUIImage;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        skillToUnlock.GetComponent<SkillUnlock>().SendMessage("UnlockSkill");

        if (skillToUnlock.CompareTag("Active"))
        {
            skillUnlockedUIImage.SetActive(true);
            skillUnlockedUIImage.tag = "ShowSkillUI";
            gameObject.SetActive(false);
            gameObject.tag = "HideAllSkillUI";
        }
        else
        {
            //Debug.Log("Unlock previous tier first");
        }
    }
}
