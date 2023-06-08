using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Image barLife;
    

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        barLife.fillAmount = health / maxHealth;
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
