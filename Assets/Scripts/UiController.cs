using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Reflection;
using Random = UnityEngine.Random;
using UnityEngine.PlayerLoop;

public class UiController : MonoBehaviour
{

    [SerializeField] GirrafeObject[] girrafeObjects;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject coinsNumber;
    [SerializeField] GameObject Footer;
    [SerializeField] GameObject PopUp;
    [SerializeField] Image bird;
    DataModule dataModule;
    public System.TimeSpan roundTime = new System.TimeSpan(0, 0, 0); 
    int lastSecond = 0; 
    string correctedSeconds;
    bool isShifted = false;
    bool buyDelay = true;
    bool birdfly = false;
    bool lionDelay = true;
    [SerializeField] GameObject lionPrefab;

    void Start()
    {
        dataModule = GetComponent<DataModule>();
        int currentUpgrade = playerData.upgrade;

        MoneyMaker currentMoneyUpgrade = dataModule.MoneyUPG[currentUpgrade];
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
                girrafeObjects[i].cost = currentGiraffeUpgrade[i].cost;
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
        if (!birdfly) StartCoroutine(Bird_Fly());
        if(lionDelay)
        {
            lionDelay = false;
            StartCoroutine(SummonLion());
        }
    }

    public void ShiftUI(GameObject obj) // UI hover animation
    {
        Animator anim = obj.GetComponent<Animator>();

        if (isShifted == false)
        {
            anim.Play("ButtonShift");
            isShifted = true;
            if (obj.name == "Upgrade" && obj.name != "Pause")
            {
                PopUp.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 300, 0);
                PopUp.SetActive(true);
            }
            else if (obj.name != "Pause")
            {
                PopUp.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 250, 0);
                PopUp.SetActive(true);
            }
        }
        else
        {
            anim.Play("ButtonShiftBack");
            isShifted = false;
            PopUp.SetActive(false);
        }

    }

    public void changePopUpText(int index)
    {
        PopUp.transform.Find("TroopName").GetComponent<TextMeshProUGUI>().text = dataModule.unitDesc[index].name;
        PopUp.transform.Find("TroopDescription").GetComponent<TextMeshProUGUI>().text = dataModule.unitDesc[index].desc;

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

            List<GiraffeTypes> currentGiraffeUpgrade = dataModule.GiraffeUpgrades[playerData.upgrade];

            Button[] footerChildren = Footer.GetComponentsInChildren<Button>();
            for (int i = 0; i < footerChildren.Length; i++)
            {
                Transform currentObject = footerChildren[i].transform;
                TextMeshProUGUI text = currentObject.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();

                if (i < 5)
                {
                   text.text = $"{currentGiraffeUpgrade[i].cost}$";
                    girrafeObjects[i].cost = currentGiraffeUpgrade[i].cost;
                }
                else if (footerChildren[i].name == "MagicSpell")
                {
                    text.text = $"{dataModule.GiraffeSpells[0].cost}";
                }
                else
                {
                    int temp = playerData.upgrade;
                    if(temp != 2)
                    {
                        temp += 1;
                    }
                    currentObject.Find("LvlText").GetComponent<TextMeshProUGUI>().text = (playerData.upgrade + 1 != 3) ? $"Lvl. {playerData.upgrade + 1}" : "Lvl. MAX";
                    text.text = $"{dataModule.GiraffeUPG[temp].cost}";
                }
            }


        }

    }

    IEnumerator Bird_Fly()
    {
        System.Random rand = new();
        Animator anim = bird.GetComponent<Animator>();

        birdfly = true;
        yield return new WaitForSeconds(rand.Next(10, 300));

        int rand_y = rand.Next(-100, 200);
        bird.transform.position = new Vector3(1170f, bird.transform.position.y + rand_y, bird.transform.position.z);

        anim.Play("birdMove", 1);
        yield return new WaitForSeconds(25);

        birdfly = false;
    }

    IEnumerator TroopIE(int index, int troopCost)
    {
        playerData.currency -= troopCost;
        GameObject go = Instantiate(girrafeObjects[index].prefab, new Vector2(-7.5f, -1.75f), Quaternion.identity);
        go.transform.parent = GameObject.Find("giraffes").transform;
        buyDelay = true;
        yield return new WaitForSeconds(0);
    }

    public void troop(int index) 
    {
        int troopCost = girrafeObjects[index].cost;

        if (buyDelay && playerData.currency >= troopCost) StartCoroutine(TroopIE(index, troopCost));
    }

    IEnumerator SummonLion()
    {
        yield return new WaitForSeconds(Random.Range(20 - roundTime.Seconds * 0.2f, 30 - roundTime.Seconds * 0.2f));
        GameObject go = Instantiate(lionPrefab, new Vector2(7.5f, -1.75f), Quaternion.identity);
        go.GetComponent<Enemy>().damage += 2 * playerData.upgrade;
        go.GetComponent<Enemy>().healthPoint += 1.5f * playerData.upgrade;
        if (playerData.upgrade <= 2)
        {
            go.GetComponent<Enemy>().damage *= 0.003f * roundTime.Seconds;
            go.GetComponent<Enemy>().healthPoint *= 0.003f * roundTime.Seconds;
        }
        go.transform.parent = GameObject.Find("Lions").transform;
        lionDelay = true;
    }

}
