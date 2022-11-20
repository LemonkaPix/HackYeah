using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Girrafe : MonoBehaviour
{
    [SerializeField] GirrafeObject girrafeObject;
    [SerializeField] PlayerData playerData;
    [SerializeField] DataModule dataModule;

    public float healthPoint;
    float damage;
    float speed;
    float lerpSpeed;
    GameObject fightingGameObject;
    bool onCollider;
    bool attackDelay = true;
    bool isDying = false;
    [SerializeField] SpriteRenderer bar;
    [SerializeField] GameObject slider;
    Animator anim;
    List<GiraffeTypes> currentGiraffeUpgrade;
    [SerializeField] AudioSource source;


    #region colliders

    private void Awake()
    {
        currentGiraffeUpgrade = dataModule.GiraffeUpgrades[playerData.upgrade];
        healthPoint = currentGiraffeUpgrade[girrafeObject.index].health;
        damage = currentGiraffeUpgrade[girrafeObject.index].damage;
        speed = currentGiraffeUpgrade[girrafeObject.index].speed;
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
                List<GiraffeTypes> currentGiraffeUpgrade = dataModule.GiraffeUpgrades[playerData.upgrade];

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
        if (healthPoint != currentGiraffeUpgrade[girrafeObject.index].health) slider.SetActive(true);

        if (transform.position.x > 11) Destroy(this.gameObject);
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        attackDelay = true;
        source.Play();
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
