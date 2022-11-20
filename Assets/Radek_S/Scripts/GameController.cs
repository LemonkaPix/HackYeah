using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] DataModule dataModule;
    [SerializeField] PlayerData playerData;
    bool active = false;
    bool isDefat = true;


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
        if(playerData.baseHealth <= 0 && isDefat) StartCoroutine(Defeat());
    }

    IEnumerator Defeat()
    {
        isDefat = false;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0);
    }
}
