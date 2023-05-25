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
        anim.SetBool("Attack", states == STATES_PLAYER.ATTACKING);
        float actualSpeedPlayerNormalized = theAgent.velocity.magnitude / theAgent.speed;
        anim.SetFloat("Mov", actualSpeedPlayerNormalized);
    }
}
