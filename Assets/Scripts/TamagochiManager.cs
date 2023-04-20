using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum STATS
{
    SATIETY, CLEAN, HAPPY
}

public class TamagochiManager : MonoBehaviour
{
    public float satiety, satietyThreshold = 10;
    public float clean, cleanThreshold = 10;
    public float happy, happyThreshold =10;
    public Image barSatiety, barClean, barHappy;

    public static TamagochiManager instance;

    private void Update()
    {
        barSatiety.fillAmount = satiety / satietyThreshold;
        barClean.fillAmount = clean / cleanThreshold;
        barHappy.fillAmount = happy / happyThreshold;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Feed(float amount)
    {
        satiety += amount;
        if(satiety > satietyThreshold)
        {
            satiety = satietyThreshold;
        }
    }
    public void Clean(float amount)
    {
        clean += amount;
        if (clean > cleanThreshold)
        {
            clean = cleanThreshold;
        }
    }
    public void Happy(float amount)
    {
        happy += amount;
        if (happy > happyThreshold)
        {
            happy = happyThreshold;
        }
    }

    public void ChangeStat(STATS stat, float amount)
    {
        switch (stat)
        {
            case STATS.SATIETY:
                Feed(amount);
                break;
            case STATS.CLEAN:
                Clean(amount);
                break;
            case STATS.HAPPY:
                Happy(amount);
                break;
        }
    }
    

}
