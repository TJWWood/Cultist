using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerResources;

public class PlayerStats : MonoBehaviour
{
    public float playerHealth;
    public float playerHunger;
    public float playerThirst;
    public float playerSanity;
    public float playerStamina;
    public float playerFatigue;
    public bool playerFatigued;
    public bool playerWellFed;
    public bool playerWellHydrated;
    public int playerSkillPoints;
    public float playerCurrentDamage;

    void Awake()
    {
        playerHealth = health;
        playerHunger = hunger;
        playerThirst = thirst;
        playerSanity = sanity;
        playerStamina = stamina;
        playerFatigue = fatigue;
        playerFatigued = isFatigued;
        playerWellFed = wellFed;
        playerWellHydrated = wellHydrated;
        playerSkillPoints = skillPoints;
        playerCurrentDamage = currentDamage;
    }

    void Update()
    {
        health = playerHealth;
        hunger = playerHunger;
        thirst = playerThirst;
        sanity = playerSanity;
        stamina = playerStamina;
        fatigue = playerFatigue;
        isFatigued = playerFatigued;
        wellFed = playerWellFed;
        wellHydrated = playerWellHydrated;
        skillPoints = playerSkillPoints;
        currentDamage = playerCurrentDamage;
    }
}
