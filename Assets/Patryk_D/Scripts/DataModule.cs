using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Object classes
public class MoneyMaker
{
    public int maxMoney;
    public int cost;
    public int mps;

    public MoneyMaker(int maxMoney, int cost, int mps)
    {
        this.maxMoney = maxMoney;
        this.cost = cost;
        this.mps = mps;
    }
}

public class GiraffeTypes
{
    public int health;
    public int damage;
    public int speed;
    public int cost;
    public int unlockPrice;

    public GiraffeTypes(int health, int damage, int speed, int cost, int unlockPrice)
    {
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.cost = cost;
        this.unlockPrice = unlockPrice;
    }
}
public class GiraffeSpells
{
    public int damage;
    public int cost;
    public int cooldown;

    public GiraffeSpells(int damage, int cost, int cooldown)
    {
        this.damage = damage;
        this.cost = cost;
        this.cooldown = cooldown;
    }
}

public class LionTypes
{
    public int health;
    public int damage;
    public int speed;
    public int spawnRate;


    public LionTypes(int health, int damage, int speed, int spawnRate)
    {
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.spawnRate = spawnRate;
    }
}

public class BaseUPG
{
    public int baseHp;
    public int cost;
    public double restoreHp;


    public BaseUPG(int baseHp, int cost, double restoreHp)
    {
        this.baseHp = baseHp;
        this.cost = cost;
        this.restoreHp = restoreHp;
    }
}


public class DataModule : MonoBehaviour
{

    // Object lists
    public List<MoneyMaker> MoneyUPG = new List<MoneyMaker>
    {
        new MoneyMaker(60,0,3),
        new MoneyMaker(80,40,4),
        new MoneyMaker(110,70,5),
        new MoneyMaker(150,90,6),
        new MoneyMaker(200,120,7)
    };

    public List<GiraffeTypes> Giraffes = new List<GiraffeTypes>
    {
        new GiraffeTypes(10, 2, 4, 3, 0),
        new GiraffeTypes(25, 5, 2, 50, 40),
        new GiraffeTypes(35, 5, 3, 70, 60),
        new GiraffeTypes(60, 2, 1, 100, 80),
        new GiraffeTypes(50, 10, 2, 150, 120),
    };

    public List<GiraffeSpells> GiraffeSpells = new List<GiraffeSpells>
    {
        new GiraffeSpells(30, 100, 60)
    };


    public List<LionTypes> BaseLion = new List<LionTypes>
    {
        new LionTypes(12, 2, 4, 10),
        new LionTypes(28, 6, 3, 15),
        new LionTypes(40, 5, 2, 20),
        new LionTypes(70, 2, 1, 30),
        new LionTypes(55, 12, 2, 60)
    };

    public List<LionTypes> LionUPG1 = new List<LionTypes> // after 90s
    {
        new LionTypes(13, 2, 4, 10),
        new LionTypes(30, 6, 3, 15),
        new LionTypes(45, 5, 2, 20),
        new LionTypes(75, 2, 1, 30),
        new LionTypes(60, 12, 2, 50)
    };

    public List<LionTypes> LionUPG2 = new List<LionTypes> // after 150s
    {
        new LionTypes(15, 2, 4, 10),
        new LionTypes(35, 6, 3, 15),
        new LionTypes(50, 6, 2, 20),
        new LionTypes(80, 2, 1, 25),
        new LionTypes(65, 13, 2, 40)
    };

    public List<LionTypes> LionUPG3 = new List<LionTypes> // after 240s
    {
        new LionTypes(20, 2, 4, 10),
        new LionTypes(35, 7, 3, 15),
        new LionTypes(55, 6, 2, 20),
        new LionTypes(90, 2, 1, 20),
        new LionTypes(75, 14, 2, 30)
    };

    public List<LionTypes> LionUPG4 = new List<LionTypes> // after 240s
    {
        new LionTypes(25, 4, 4, 7),
        new LionTypes(40, 8, 3, 10),
        new LionTypes(60, 6, 3, 10),
        new LionTypes(100, 3, 2, 15),
        new LionTypes(85, 16, 2, 20)
    };

    public List<BaseUPG> BaseUpg = new List<BaseUPG>
    {
        new BaseUPG(20, 0, 0),
        new BaseUPG(30, 25, 0),
        new BaseUPG(40, 40, 0.5),
        new BaseUPG(50, 70, 1),
        new BaseUPG(70, 90, 2)
    };

}
