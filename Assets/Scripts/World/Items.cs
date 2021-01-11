using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public enum Foods
    {
        Cake,
        Banana,
        Apple
    }
    public static Foods foods;

    public enum Drinks
    {
        Water,
        Alcohol,
        Milk
    }
    public static Drinks drinks;

    public enum Meds
    {
        Painkillers,
        Steroids,
        PsychPills
    }
    public static Meds meds;
}
