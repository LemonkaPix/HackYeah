using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girrafe : MonoBehaviour
{
    [SerializeField] GirrafeObject girrafeObject;

    float healthPoint;
    float damage;
    float speed;

    GameObject fightingGameObject;
    bool onCollider;
    bool attackDelay = true;
    #region colliders

    private void Awake()
    {
        healthPoint = girrafeObject.HealthPoint;
        damage = girrafeObject.Damage;
        speed = girrafeObject.Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
        if(!onCollider) transform.position += new Vector3(Time.deltaTime * girrafeObject.Speed,0);
        else if (attackDelay)
        {
            StartCoroutine(Attack());
            attackDelay = false;
        }

        if (girrafeObject.HealthPoint <= 0) StartCoroutine(Die());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        fightingGameObject.GetComponent<Enemy>().girrafeObject.HealthPoint -= girrafeObject.Damage;
        attackDelay = true;
        Debug.Log("ATTACK");
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
