using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GirrafeObject girrafeObject;
    GameObject fightingGameObject;
    bool onCollider;
    #region colliders
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
        if (!onCollider) transform.position -= new Vector3(Time.deltaTime * girrafeObject.Speed, 0);
        else
        {

        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
