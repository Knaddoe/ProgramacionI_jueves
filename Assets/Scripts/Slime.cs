using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Slime : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    [SerializeField] private int nextLevel = 10;
    Tween tween;
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private int expToAddForClick = 1;
    [SerializeField] private GameObject panelExpAdd;
    [SerializeField] private Transform spawnPoint;
    private void Start()
    {
        tween = transform.DOShakeScale(.5f)
            .SetAutoKill(false).SetRecyclable(true).Pause();
        textLevel.text = "Level: " + level;
    }

    private void OnMouseDown()
    {
        AddExperience(expToAddForClick);
        transform.localScale = new Vector3(1, 1, 1);
        tween.Restart();
    }
    public void AddExperience(int expToAdd)
    {
        exp += expToAdd;
        GameObject panel = Instantiate(panelExpAdd, spawnPoint);
        panel.GetComponentInChildren<TextMeshProUGUI>().text 
            = "+" + expToAdd;
        panel.transform.DOLocalMoveY(2, .5f);
        panel.transform.localPosition = 
            new Vector3(Random.Range(-.5f,.5f),0,0);
        Destroy(panel, .5f);
        if (exp >= nextLevel)
        {
            exp -= nextLevel;
            LevelUp();
        }
        bar.fillAmount = (float)(exp) / (float)(nextLevel);

    }
    private void LevelUp()
    {
        level++;
        nextLevel = (int)(nextLevel * 1.25f + nextLevel);
        textLevel.text = "Level: " + level;
    }
    public void AddToExpForClick(int newExpForClick)
    {
        expToAddForClick += newExpForClick;
    }
}
