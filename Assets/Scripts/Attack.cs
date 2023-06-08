using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]private Health target;
    public float damage;
    public string tagTarget = "Enemy";
    public States selfState;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagTarget))
        {
            target = other.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagTarget))
        {
            target = null;
        }
    }

    public void AttackMelee()
    {
        target.TakeDamage(damage);
        if (target.health <= 0)
        {
            selfState.states = STATES_PLAYER.IDLE;
        }
    }
}
