using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UiController : MonoBehaviour
{

    [SerializeField] GirrafeObject[] girrafeObjects;
    [SerializeField] PlayerData playerData;
    public int currentMoney;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject coinsNumber;
    System.TimeSpan roundTime = new System.TimeSpan(0, 0, 0); //clock
    int lastSecond = 0; //pomocna zmienna do update'owania timera co sekunde
    string correctedSeconds;


    // Update is called once per frame
    void Update()
    {
        if (Time.time - 1 >= lastSecond) { //funkcja odpala sie co sekunde
            lastSecond = Mathf.FloorToInt(Time.time);
            roundTime = roundTime.Add(new System.TimeSpan(0, 0, 1));
        }
        correctedSeconds = Convert.ToString(roundTime.Seconds).Length < 2 ?
            "0" + roundTime.Seconds : Convert.ToString(roundTime.Seconds); //Dodaje 0 do sekund gdy jest to potrzebne
        timer.GetComponent<TMP_Text>().text = Convert.ToString(
                roundTime.Minutes + ":" + correctedSeconds); //aktualizacja textu timera


        int time = Convert.ToInt32(roundTime.Minutes * 60 + roundTime.Seconds);
        playerData.time = time;//updatuje playerData(time)


        coinsNumber.GetComponent<TMP_Text>().text = Convert.ToString(playerData.currency);
    }

    public void upgrade() {
        //upgrade tego typu benc
    }

    public void pause() {
    }

    public void troop1() {
        int troopCost = girrafeObjects[0].cost;
        if (currentMoney < troopCost) return;
        Instantiate(girrafeObjects[0], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop2() {
        int troopCost = girrafeObjects[1].cost;
        if (currentMoney < troopCost) return;
        Instantiate(girrafeObjects[1], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop3() {
        int troopCost = girrafeObjects[2].cost;
        if (currentMoney < troopCost) return;
        Instantiate(girrafeObjects[2], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop4() {
        int troopCost = girrafeObjects[3].cost;
        if (currentMoney < troopCost) return;
        Instantiate(girrafeObjects[3], new Vector2(0, 0), Quaternion.identity);
    }

    public void troop5() {
        int troopCost = girrafeObjects[4].cost;
        if (currentMoney < troopCost) return;
        Instantiate(girrafeObjects[4], new Vector2(0, 0), Quaternion.identity);
    }
}
