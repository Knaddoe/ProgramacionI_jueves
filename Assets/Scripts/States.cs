using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum STATES_PLAYER
{
    IDLE, RUNNING, RUNNING_TO_ATTACK, ATTACKING, BLEEDING
}
public class States : MonoBehaviour
{
    public STATES_PLAYER states;
}
