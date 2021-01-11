using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static float health = 100.0f;
    public static float hunger = 100.0f;
    public static float thirst = 100.0f;
    public static float sanity = 100.0f;
    public static float stamina = 100.0f;
    public static float fatigue = 100.0f;
    public static bool isFatigued = false;
    public static bool wellFed = false;
    public static bool wellHydrated = false;
    public static int skillPoints = 0;
    public static float currentDamage = 10f;
}
