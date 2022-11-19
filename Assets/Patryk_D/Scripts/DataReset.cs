using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    void Start()// Resetting data
    {
        // Main
        playerData.currency = 0;
        playerData.baseHealth = 100;
        playerData.maxbaseHealth = 100;
        playerData.time = 0;
        playerData.upgrade = 0;
        // Statistics
        playerData.totalCurrency = 0;
        playerData.totalBabyKilled = 0;
        playerData.totalAFKilled = 0;
        playerData.totalAMKilled = 0;
        playerData.totalTankyKilled = 0;
        playerData.totalKingsKilled = 0;
    }




}
