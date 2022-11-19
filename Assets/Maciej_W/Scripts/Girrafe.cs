using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Girrafe : MonoBehaviour
{
    [SerializeField] GirrafeObject girrafeObject;

    [HideInInspector] public float healthPoint;
    float damage;
    float speed;

    GameObject fightingGameObject;
    bool onCollider;
    bool attackDelay = true;
    bool isDying = false;
    [SerializeField] SpriteRenderer bar;
    float lerpSpeed;
    [SerializeField] GameObject slider;
    Animator anim;

    #region colliders

    private void Awake()
    {
        healthPoint = girrafeObject.HealthPoint;
        damage = girrafeObject.Damage;
        speed = girrafeObject.Speed;
        anim = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollider = true;
        fightingGameObject = collision.gameObject;
        anim.SetBool("IsAttacking", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("IsAttacking", false);
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

        lerpSpeed = 3f * Time.deltaTime;
        ColorLerp();
        bar.transform.localScale = new Vector3(healthPoint / girrafeObject.HealthPoint, bar.transform.localScale.y, bar.transform.localScale.z);
        if (healthPoint != girrafeObject.HealthPoint) slider.SetActive(true);

        if (transform.position.x > 11) Destroy(this.gameObject);
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

    void ColorLerp()
    {
        Color hpColor = Color.Lerp(Color.red, Color.green, healthPoint / girrafeObject.HealthPoint);

        bar.color = hpColor;
    }

}
