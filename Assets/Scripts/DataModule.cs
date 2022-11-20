using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Object classes
public class MoneyMaker
{
    public int maxMoney;
    public int mps;

    public MoneyMaker(int maxMoney, int mps)
    {
        this.maxMoney = maxMoney;
        this.mps = mps;
    }
}

public class GiraffeUPG
{
    public int cost;

    public GiraffeUPG(int cost)
    {
        this.cost = cost;
    }
}

public class GiraffeTypes
{
    public int health;
    public int damage;
    public int speed;
    public int cost;
    public int? unlockPrice;

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

public class unitDescriptions
{
    public string name;
    public string desc;

    public unitDescriptions(string name, string desc)
    {
        this.name = name;
        this.desc = desc;
    }
}


public class DataModule : MonoBehaviour
{

    // Object lists
    public List<MoneyMaker> MoneyUPG = new List<MoneyMaker>
    {
        new MoneyMaker(150,3),
        new MoneyMaker(250,5),
        new MoneyMaker(500,7)
    };

    public List<GiraffeUPG> GiraffeUPG = new List<GiraffeUPG>
    {
        new GiraffeUPG(0),
        new GiraffeUPG(100),
        new GiraffeUPG(200),
        new GiraffeUPG(200)

    };


    public List<GiraffeSpells> GiraffeSpells = new List<GiraffeSpells> // damage, cost, cooldown
    {
        new GiraffeSpells(30, 100, 60)
    };

    public List<List<GiraffeTypes>> GiraffeUpgrades = new List<List<GiraffeTypes>> { }; // health, damage, speed, cost, unlock

    List<GiraffeTypes> GiraffeBase = new List<GiraffeTypes>()
    {
        new GiraffeTypes(10, 2, 4, 30, 0),
        new GiraffeTypes(25, 5, 2, 50, 40),
        new GiraffeTypes(35, 5, 3, 70, 60),
        new GiraffeTypes(60, 2, 1, 100, 80),
        new GiraffeTypes(50, 10, 2, 150, 120),
    };

    List<GiraffeTypes> GiraffeUPG1 = new List<GiraffeTypes>()
    {
        new GiraffeTypes(13, 2, 4, 40, 0),
        new GiraffeTypes(26, 6, 2, 60, 40),
        new GiraffeTypes(40, 5, 3, 90, 60),
        new GiraffeTypes(70, 1, 1, 120, 80),
        new GiraffeTypes(65, 12, 2, 200, 120)
    };

    List<GiraffeTypes> GiraffeUPG2 = new List<GiraffeTypes>()
    {
        new GiraffeTypes(16, 3, 4, 60, 0),
        new GiraffeTypes(26, 6, 2, 60, 40),
        new GiraffeTypes(40, 5, 3, 90, 60),
        new GiraffeTypes(70, 1, 1, 120, 80),
        new GiraffeTypes(75, 14, 2, 300, 120),
    };


    public List<List<LionTypes>> LionUpgrades = new List<List<LionTypes>> { }; // health, damage, speed, spawnrate

    List<LionTypes> LionBase = new List<LionTypes>()
    {
        new LionTypes(12, 2, 4, 10),
        new LionTypes(28, 6, 3, 15),
        new LionTypes(40, 5, 2, 20),
        new LionTypes(70, 2, 1, 30),
        new LionTypes(55, 12, 2, 60)
    };

    List<LionTypes> LionUPG1 = new List<LionTypes>()
    {
        new LionTypes(13, 2, 4, 10),
        new LionTypes(30, 6, 3, 15),
        new LionTypes(45, 5, 2, 20),
        new LionTypes(75, 2, 1, 30),
        new LionTypes(60, 12, 2, 50)
    };

    List<LionTypes> LionUPG2 = new List<LionTypes>()
    {
        new LionTypes(15, 2, 4, 10),
        new LionTypes(35, 6, 3, 15),
        new LionTypes(50, 6, 2, 20),
        new LionTypes(80, 2, 1, 25),
        new LionTypes(65, 13, 2, 40)
    };

    List<LionTypes> LionUPG3 = new List<LionTypes>()
    {
        new LionTypes(20, 2, 4, 10),
        new LionTypes(35, 7, 3, 15),
        new LionTypes(55, 6, 2, 20),
        new LionTypes(90, 2, 1, 20),
        new LionTypes(75, 14, 2, 30)
    };

    List<LionTypes> LionUPG4 = new List<LionTypes>()
    {
        new LionTypes(25, 4, 4, 7),
        new LionTypes(40, 8, 3, 10),
        new LionTypes(60, 6, 3, 10),
        new LionTypes(100, 3, 2, 15),
        new LionTypes(85, 16, 2, 20)
    };


    public List<unitDescriptions> unitDesc = new List<unitDescriptions>()
    {
       new unitDescriptions("Baby", "It's cheap but it's also weak. Don't rely on it too much"),
       new unitDescriptions("Basic", "Your average troop. Not too strong nor weak"),
       new unitDescriptions("Tall", "A really tall one"),
       new unitDescriptions("Chunky", "This one can tank a lot of hits"),
       new unitDescriptions("Epic", "The best of them all"),
       new unitDescriptions("Flying Giraffe", "A mysterious giraffe that wreaks chaos"),
       new unitDescriptions("Upgrade", "Upgrading boosts all your troops!")
    };

    void Awake() // Adding objects
    {
        LionUpgrades.Add(LionBase);
        LionUpgrades.Add(LionUPG1);
        LionUpgrades.Add(LionUPG2);
        LionUpgrades.Add(LionUPG3);
        LionUpgrades.Add(LionUPG4);

        GiraffeUpgrades.Add(GiraffeBase);
        GiraffeUpgrades.Add(GiraffeUPG1);
        GiraffeUpgrades.Add(GiraffeUPG2);
    }


}