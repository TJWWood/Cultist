using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStats : MonoBehaviour
{
    public GameObject player;
    public GameObject healthText;
    public GameObject hungerText;
    public GameObject thirstText;
    public GameObject sanityText;
    public GameObject staminaText;
    public GameObject fatigueText;
    public GameObject skillPointText;

    TextMeshProUGUI healthMesh;
    TextMeshProUGUI hungerMesh;
    TextMeshProUGUI thirstMesh;
    TextMeshProUGUI sanityMesh;
    TextMeshProUGUI staminaMesh;
    TextMeshProUGUI fatigueMesh;
    TextMeshProUGUI skillPointMesh;

    void Start()
    {
        healthMesh = healthText.GetComponent<TextMeshProUGUI>();
        hungerMesh = hungerText.GetComponent<TextMeshProUGUI>();
        thirstMesh = thirstText.GetComponent<TextMeshProUGUI>();
        sanityMesh = sanityText.GetComponent<TextMeshProUGUI>();
        staminaMesh = staminaText.GetComponent<TextMeshProUGUI>();
        fatigueMesh = fatigueText.GetComponent<TextMeshProUGUI>();
        skillPointMesh = skillPointText.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        healthMesh.text = "Health: " + (int)player.GetComponent<PlayerStats>().playerHealth;
        hungerMesh.text = "Hunger: " + (int)player.GetComponent<PlayerStats>().playerHunger;
        thirstMesh.text = "Thirst: " + (int)player.GetComponent<PlayerStats>().playerThirst;
        sanityMesh.text = "Sanity: " + (int)player.GetComponent<PlayerStats>().playerSanity;
        staminaMesh.text = "Stamina: " + (int)player.GetComponent<PlayerStats>().playerStamina;
        fatigueMesh.text = "Fatigue: " + (int)player.GetComponent<PlayerStats>().playerFatigue;
        skillPointMesh.text = "Skill Points: " + player.GetComponent<PlayerStats>().playerSkillPoints;
    }
}
