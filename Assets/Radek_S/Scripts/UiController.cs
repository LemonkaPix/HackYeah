using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{

    [SerializeField] GirrafeObject[] girrafeObjects;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject coinsNumber;
    [SerializeField] GameObject Footer;
    DataModule dataModule;
    System.TimeSpan roundTime = new System.TimeSpan(0, 0, 0); 
    int lastSecond = 0; 
    string correctedSeconds;
    bool isShifted = false;

    void Start()
    {
        dataModule = GetComponent<DataModule>();
        int currentUpgrade = playerData.upgrade;

        MoneyMaker currentMoneyUpgrade = dataModule.MoneyUPG[currentUpgrade];
        coinsNumber.transform.parent.Find("CoinsIncome").GetComponent<TextMeshProUGUI>().text = $"{currentMoneyUpgrade.mps}c/s";


        List<GiraffeTypes> currentGiraffeUpgrade = dataModule.GiraffeUpgrades[currentUpgrade];
        Debug.Log(dataModule.GiraffeUpgrades.Count);
        Button[] footerChildren = Footer.GetComponentsInChildren<Button>();
        for (int i = 0; i < footerChildren.Length; i++)
        {
            Transform currentObject = footerChildren[i].transform;
            TextMeshProUGUI text = currentObject.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();
            if (i < 5)
            {
                text.text = $"{currentGiraffeUpgrade[i].cost}$";
            }
            else
            {
                text.text = $"{dataModule.GiraffeUPG[currentUpgrade + 1].cost}";
            }
        }

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



        coinsNumber.GetComponent<TMP_Text>().text = $"Giraffe coins: {Convert.ToString(playerData.currency)}";
    }


    public void ShiftUI(GameObject obj) // UI hover animation
    {
        Animator anim = obj.GetComponent<Animator>();

        if (isShifted == false)
        {
            Debug.Log("played");
            anim.Play("ButtonShift");
            isShifted = true;
        }
        else
        {
            anim.Play("ButtonShiftBack");
            isShifted = false;
        }

    }

    public void upgrade() {
        //upgrade giraffes
        int currentUpgrade = playerData.upgrade;
        if (currentUpgrade != 2 && playerData.currency >= dataModule.GiraffeUPG[currentUpgrade + 1].cost)
        {
            playerData.upgrade += 1;
            playerData.currency -= dataModule.GiraffeUPG[currentUpgrade + 1].cost;

            MoneyMaker currentMoneyUpgrade = dataModule.MoneyUPG[playerData.upgrade];
            coinsNumber.transform.parent.Find("CoinsIncome").GetComponent<TextMeshProUGUI>().text = $"{currentMoneyUpgrade.mps}c/s";

            List<GiraffeTypes> currentGiraffeUpgrade = dataModule.GiraffeUpgrades[currentUpgrade];

            Button[] footerChildren = Footer.GetComponentsInChildren<Button>();
            for (int i = 0; i < footerChildren.Length; i++)
            {
                Transform currentObject = footerChildren[i].transform;
                TextMeshProUGUI text = currentObject.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();

                if (i < 5)
                {
                   text.text = $"{currentGiraffeUpgrade[i].cost}$";
                }
                else if (footerChildren[i].name == "MagicSpell")
                {
                    text.text = $"{dataModule.GiraffeSpells[0].cost}";
                }
                else
                {
                    int upgradeIndex;
                    if (playerData.upgrade == 2)
                    {
                         upgradeIndex = playerData.upgrade;
                    }
                    else
                    {
                         upgradeIndex = playerData.upgrade + 1;
                    }
                    currentObject.Find("LvlText").GetComponent<TextMeshProUGUI>().text = $"Lvl. {playerData.upgrade + 1}";
                    text.text = $"{dataModule.GiraffeUPG[upgradeIndex].cost}";
                }
            }


        }

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
