using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    [SerializeField] GirrafeObject[] girrafeObjects;

    public int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade() {
        //upgrade tego typu benc
    }

    public void pause() {
        if (Time.timeScale == 1)
        Time.timeScale = 0;
        else
        Time.timeScale = 1;
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
