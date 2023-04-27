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
    public ParticleSystem sickParticles;
    public Animator anim;

    public static TamagochiManager instance;

    private void Update()
    {
        barSatiety.fillAmount = GetSatiety();
        barClean.fillAmount = GetClean();
        barHappy.fillAmount = GetHappy();
        if (GetClean() < .25f || GetSatiety() < .25f || 
            GetHappy() < .25f)
        {
            anim.SetBool("Sad", true);
            if (sickParticles.isStopped)
            {
                sickParticles.Play();
            }
        }
        else
        {
            anim.SetBool("Sad", false);
            if (!sickParticles.isStopped)
            {
                sickParticles.Stop();
            }
        }

        if (GetClean() > .75f || GetSatiety() > .75f ||
            GetHappy() > .75f)
        {
            anim.SetBool("Happy", true);
        }
        else
        {
            anim.SetBool("Happy", false);
        }
    }

    public float GetSatiety()
    {
        return satiety / satietyThreshold; 
    }
    public float GetClean()
    {
        return clean / cleanThreshold;
    }
    public float GetHappy()
    {
        return happy / happyThreshold;
    }
    private void Awake()
    {
        instance = this;
    }

    public void Feed(float amount)
    {
        anim.SetBool("Eat", true);
        satiety += amount;
        if(satiety > satietyThreshold)
        {
            satiety = satietyThreshold;
        }
    }

    public void SetEat()
    {
        anim.SetBool("Eat", false);
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
