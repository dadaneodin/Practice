using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;



public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    
    public Image RaidTimerImg;
    public Image PeasantTimerImg;
    public Image WarriorTimerImg;
    

    public Button peasantButton;
    public Button warriorButton;


    public Text resourcesText;

    public int peasantCount;
    public int warriorsCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;
    
    public int peasantCost;
    public int warriorCost;

    public float peasantCreateTime;
    public float warriorCreateTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;

    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;


    void Start()
    {
        UpdateText();
    }

   
    void Update()
    {


        wheatCount += peasantCount * wheatPerPeasant;
        wheatCount -= warriorsCount * wheatToWarriors;
        /*if (HarvestTimer.Tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (EatingTimer.Tick) 
        {
            wheatCount -= warriorsCount * wheatToWarriors;
        }*/

        UpdateText();
    }

    public void CreatePeasant()
    {

    }

    public void CreateWarrior()
    {
        
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount +"\n" + warriorsCount +"\n\n" + wheatCount;
    }
}