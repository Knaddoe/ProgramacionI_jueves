using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Animator anim;
    public States enemyStates;
    public Health health;
    public Transform target;

    private void Update()
    {
        anim.SetBool("Attack", enemyStates.states == STATES_PLAYER.ATTACKING);
        if (health.health <=0)
        {
            anim.SetBool("Die", true);
        }

        if (enemyStates.states == STATES_PLAYER.ATTACKING)
        {
            if (target == null)
            {
                enemyStates.states = STATES_PLAYER.IDLE;
            }
            else
            {
                // Create a rotation based on the direction to the target
                Vector3 directionToTarget = target.position - transform.position;
                directionToTarget.y = 0; // This line ensures that the agent only rotates around the y-axis
                Quaternion rotation = Quaternion.LookRotation(directionToTarget);

                // Smoothly rotate the agent to this new rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyStates.states = STATES_PLAYER.ATTACKING;
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyStates.states = STATES_PLAYER.IDLE;
            target = null;
        }
    }
}
