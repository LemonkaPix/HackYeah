using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UiController : MonoBehaviour
{

    [SerializeField] GirrafeObject[] girrafeObjects;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject coinsNumber;
    DataModule dataModule;
    System.TimeSpan roundTime = new System.TimeSpan(0, 0, 0); 
    int lastSecond = 0; 
    string correctedSeconds;

    void Start()
    {
        dataModule = GetComponent<DataModule>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - 1 >= lastSecond) { 
            lastSecond = Mathf.FloorToInt(Time.time);
            roundTime = roundTime.Add(new System.TimeSpan(0, 0, 1));
        }
        correctedSeconds = Convert.ToString(roundTime.Seconds).Length < 2 ?
            "0" + roundTime.Seconds : Convert.ToString(roundTime.Seconds); 
        timer.GetComponent<TMP_Text>().text = Convert.ToString(
                roundTime.Minutes + ":" + correctedSeconds); 


        int time = Convert.ToInt32(roundTime.Minutes * 60 + roundTime.Seconds);
        playerData.time = time;


        coinsNumber.GetComponent<TMP_Text>().text = Convert.ToString(playerData.currency);
    }

    public void upgrade() {
        //upgrade giraffes
        int currentUpgrade = playerData.upgrade;
        if (currentUpgrade != 2 && playerData.currency >= dataModule.GiraffeUPG[currentUpgrade].cost)
        {
            playerData.currency -= dataModule.GiraffeUPG[currentUpgrade].cost;
            playerData.upgrade += 1;   
        }
    }

    public void pause() {
    }

    public void troop1() {
        int troopCost = girrafeObjects[0].cost;
        if (playerData.currency < troopCost) return;
        Instantiate(girrafeObjects[0], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop2() {
        int troopCost = girrafeObjects[1].cost;
        if (playerData.currency < troopCost) return;
        Instantiate(girrafeObjects[1], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop3() {
        int troopCost = girrafeObjects[2].cost;
        if (playerData.currency < troopCost) return;
        Instantiate(girrafeObjects[2], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop4() {
        int troopCost = girrafeObjects[3].cost;
        if (playerData.currency < troopCost) return;
        Instantiate(girrafeObjects[3], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop5() {
        int troopCost = girrafeObjects[4].cost;
        if (playerData.currency < troopCost) return;
        Instantiate(girrafeObjects[4], new Vector2(0, 0), Quaternion.identity);
    }
}
