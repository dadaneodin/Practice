using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;



public class GameManager : MonoBehaviour
{
    private const bool V = true;
    public GameObject GameOverBack;
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

    private bool Tick;

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
        raidTimer = raidMaxTime;
    }

   
    void Update()
    {
        {
            raidTimer -= Time.deltaTime;
            RaidTimerImg.fillAmount = raidTimer / raidMaxTime;
            if (raidTimer <= 0)
            {
                raidTimer = raidMaxTime;
                warriorsCount -= nextRaid;
                nextRaid += raidIncrease;
                raidMaxTime += 7;
            }
        }

        if(peasantButton)

        if (wheatCount > 4)
        {
            peasantButton.interactable = true;
            warriorButton.interactable = true;
        }
        if(wheatCount < 4)
        {
            peasantButton.interactable = false;
            warriorButton.interactable = false;
        }


        if (HarvestTimer.Tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }
        

        if (EatingTimer.Tick)
        {
            wheatCount -= warriorsCount * wheatToWarriors;
        }

        UpdateText();

        if (Tick)
        {
            peasantButton.interactable = false;
        }


        if (peasantTimer > 0)
        {
            
            peasantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
            // peasantButton.interactable = false;
        }
        else if  (peasantTimer > -1)
        {
            PeasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            peasantTimer = -2;
        }

        if(warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
            //warriorButton.interactable = false;
        }
        else if (warriorTimer > -1)
        {
            WarriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorsCount += 1;
            warriorTimer = -2;
        }
        
        
        

        if (warriorsCount < 0 )
        {
            GameOverBack.SetActive(true);
        }
            Tick = false;
    }

        
    public void CreatePeasant()
    {
        Tick = true;
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }



    public void CreateWarrior()
    {
        Tick = true;
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount +"\n" + warriorsCount +"\n\n" + wheatCount;
    }
}