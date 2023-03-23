using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int puntaje;
    public TextMeshProUGUI textScore;
    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int ptj)
    {
        puntaje += ptj;
    }
    private void Update()
    {
        textScore.text = puntaje.ToString();
        if(puntaje <= 0)
        {
            puntaje = 0;
        }
    }
}
