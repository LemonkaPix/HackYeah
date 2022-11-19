using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girrafe : MonoBehaviour
{
    [SerializeField] GirrafeObject girrafeObject;

    public float healthPoint;
    float damage;
    float speed;

    GameObject fightingGameObject;
    bool onCollider;
    bool attackDelay = true;
    bool isDying = false;
    #region colliders

    private void Awake()
    {
        healthPoint = girrafeObject.HealthPoint;
        damage = girrafeObject.Damage;
        speed = girrafeObject.Speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollider = true;
        fightingGameObject = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onCollider = false;
    }


    #endregion
    private void Update()
    {
        if(!onCollider && !isDying) transform.position += new Vector3(Time.deltaTime * speed,0);
        else if (attackDelay && onCollider && !isDying)
        {
            StartCoroutine(Attack());
            attackDelay = false;
        }
        try
        { fightingGameObject.GetComponent<Enemy>().healthPoint -= damage * Time.deltaTime * 0.5f; }
        catch { }


        if (healthPoint <= 0) StartCoroutine(Die());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        attackDelay = true;
    }
    IEnumerator Die()
    {
        isDying = true;
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(0f);
        Destroy(this.gameObject);
    }
}
