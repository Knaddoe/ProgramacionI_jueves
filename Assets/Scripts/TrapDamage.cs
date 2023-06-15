using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private Attack _attack;

    private void Start()
    {
        _attack = GetComponent<Attack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _attack.AttackMelee();
        
    }
}
