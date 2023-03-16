using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int puntaje;
    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int ptj)
    {
        puntaje += ptj;
    }
}
