using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStat : MonoBehaviour
{
    public STATS statToChange;
    public float amountToChange;

    public void GiveStat()
    {
        TamagochiManager.instance.ChangeStat(statToChange, amountToChange);
    }
}
