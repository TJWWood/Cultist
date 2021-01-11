using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUnlock : MonoBehaviour
{
    public List<string> statChanges;
    public GameObject preReqSkill;
    public GameObject skillImage;
    public GameObject player;
    public GameObject skillToUnlock;
    bool skillPointUsed;

    // Update is called once per frame
    void UnlockSkill()
    {
        if (preReqSkill.CompareTag("Active") && player.gameObject.GetComponent<PlayerStats>().playerSkillPoints > 0)
        {
            gameObject.tag = "Active";
            skillImage.tag = "ShowSkillUI";
            player.transform.Find(skillToUnlock.name).gameObject.SetActive(true);
            if(!skillPointUsed)
            { 
                player.gameObject.GetComponent<PlayerStats>().playerSkillPoints--;
                skillPointUsed = true;
            }
            //Debug.Log("Stat changes: " + statChanges[0] + ", " + statChanges[1]);
        }
        else
        {
            //Debug.Log("PreReq inactive");
        }
    }
    
}
