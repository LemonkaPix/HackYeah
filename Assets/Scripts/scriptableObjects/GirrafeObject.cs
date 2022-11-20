using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Girrafe")]
public class GirrafeObject : ScriptableObject
{
    public string Name;
    public string Description;

    public int cost;

    public float HealthPoint;
    public float Damage;

    public float Speed;

    public GameObject prefab;

    public int index;
}
