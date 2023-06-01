using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        transform.localScale = Vector3.one;
        transform.DOScale(new Vector3(0.2f, -0.2f, 0), .25f).SetRelative(true).SetLoops(2,LoopType.Yoyo);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject,5);
        }
    }
}
