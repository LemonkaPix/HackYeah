using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DataModule dataModule;
    [SerializeField] PlayerData playerData;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        dataModule = GetComponent<DataModule>();
    }


    IEnumerator PassiveIncome()
    {
        MoneyMaker currentUpgrade = dataModule.MoneyUPG[playerData.upgrade];
        active = true;

        yield return new WaitForSeconds(1f);
        playerData.currency += currentUpgrade.mps;

        if (playerData.currency >= currentUpgrade.maxMoney)
        {
            playerData.currency = currentUpgrade.maxMoney;
            yield return null;
        }

        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!active) StartCoroutine(PassiveIncome());
    }
}
