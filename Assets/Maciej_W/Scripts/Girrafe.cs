using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] SpriteRenderer bar;
    [SerializeField] SpriteRenderer slider;
    float lerpSpeed;
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

        lerpSpeed = 3f * Time.deltaTime;
        HealthBarLerp();
        ColorLerp();

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

    void HealthBarLerp()
    {
        float startHealth = slider.transform.localScale.x;

        slider.transform.localScale = new Vector3(Mathf.Lerp(startHealth, healthPoint / girrafeObject.HealthPoint, lerpSpeed), slider.transform.localScale.y, slider.transform.localScale.z);
    }

    void ColorLerp()
    {

        Color hpColor = Color.Lerp(Color.red, Color.green, healthPoint / girrafeObject.HealthPoint);

        bar.color = hpColor;
    }

}
