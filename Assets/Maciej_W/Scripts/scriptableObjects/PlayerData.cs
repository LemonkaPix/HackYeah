using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "playerData")]
public class PlayerData : ScriptableObject
{

    [Header("Main")]

    public int currency;

    public float baseHealth = 100;
    public float maxbaseHealth = 100;

    public int time;

    public int upgrade;


    [Header("Statistics")]

    public int totalCurrency;

    public int totalBabyKilled;

    public int totalAFKilled;

    public int totalAMKilled;

    public int totalTankyKilled;

    public int totalKingsKilled;

    [Header("Settings")]

    public bool Fullscreen = true;

    public int volume = 50;
    public int maxVolume = 100;
}