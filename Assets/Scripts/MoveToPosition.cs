using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum STATES_PLAYER
{
    IDLE, RUNNING, RUNNING_TO_ATTACK, ATTACKING
}
public class MoveToPosition : MonoBehaviour
{
    public NavMeshAgent theAgent;
    public Animator anim;
    public STATES_PLAYER states;
    public Transform target;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Ground":
                        theAgent.SetDestination(hit.point);
                        states = STATES_PLAYER.RUNNING;
                        break;
                    case "Enemy":
                        theAgent.SetDestination(hit.transform.position);
                        states = STATES_PLAYER.RUNNING_TO_ATTACK;
                        target = hit.transform;
                        break;
                }
            }
        }

        if (theAgent.remainingDistance <= theAgent.stoppingDistance && !theAgent.pathPending)
        {
            switch (states)
            {
                case STATES_PLAYER.RUNNING:
                    states = STATES_PLAYER.IDLE;
                    break;
                case STATES_PLAYER.RUNNING_TO_ATTACK:
                    states = STATES_PLAYER.ATTACKING;
                    break;
            }
        }

        if (states == STATES_PLAYER.ATTACKING)
        {
            if (target == null)
            {
                states = STATES_PLAYER.IDLE;
            }
            else
            {
                // Create a rotation based on the direction to the target
                Vector3 directionToTarget = target.position - transform.position;
                directionToTarget.y = 0; // This line ensures that the agent only rotates around the y-axis
                Quaternion rotation = Quaternion.LookRotation(directionToTarget);

                // Smoothly rotate the agent to this new rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*2);
            }
           
        }
        
        anim.SetBool("Attack", states == STATES_PLAYER.ATTACKING);
        float actualSpeedPlayerNormalized = theAgent.velocity.magnitude / theAgent.speed;
        anim.SetFloat("Mov", actualSpeedPlayerNormalized);
    }
}
