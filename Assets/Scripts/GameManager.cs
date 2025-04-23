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
    public GameObject GameOverBack;
    public GameObject WinBack;
    public GameObject PauseMenu;
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;

    public Image RaidTimerImg;
    public Image PeasantTimerImg;
    public Image WarriorTimerImg;

    public Button peasantButton;
    public Button warriorButton;
    public Button pauseButt;
    public Button soundButt;

    public Text resourcesText;
    public Text soundButtText;

    public int peasantCount;
    public int warriorsCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;
    
    public int peasantCost;
    public int warriorCost;

    public AudioSource audioSource;
    public AudioClip harvestSound;
    public AudioClip raidSound;
    public AudioClip peasantSound;
    public AudioClip warriorsSound;
    public AudioClip eatSound;



    public float peasantCreateTime;
    public float warriorCreateTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;
    public int wheatForWin = 500;

    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private bool isPaused = false;
    private bool soundEnabled = true;


    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
        audioSource = GetComponent<AudioSource>();
        soundButtText.text = soundEnabled ? "ВКЛ" : "ВЫКЛ";
        GameOverBack.SetActive(true);
        PauseMenu.SetActive(false);
        WinBack.SetActive(false);
    }

   
void Update()
{
    if (isPaused) return;

    raidTimer -= Time.deltaTime;
    RaidTimerImg.fillAmount = raidTimer / raidMaxTime;
    if (raidTimer <= 0)
    {
        warriorsCount -= nextRaid;
        nextRaid += raidIncrease;
        raidMaxTime += 7;
        raidTimer = raidMaxTime;
        PlaySound(raidSound);
    }

    if (HarvestTimer.Tick)
    {
        wheatCount += peasantCount * wheatPerPeasant;
        if(peasantCount > 0)
        PlaySound(harvestSound);
    }

    
    if (EatingTimer.Tick)
    {
        wheatCount -= warriorsCount * wheatToWarriors;
        if(warriorsCount > 0)
        PlaySound(eatSound);
    }

    UpdateText();

    if (peasantTimer > 0)
    {
        peasantTimer -= Time.deltaTime;
        PeasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
    }
    else if (peasantTimer > -1)
    {
        PeasantTimerImg.fillAmount = 1;
        peasantCount += 1;
        peasantTimer = -2;
        PlaySound(peasantSound);
    }

    if (warriorTimer > 0)
    {
        warriorTimer -= Time.deltaTime;
        WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
    }
    else if (warriorTimer > -1)
    {
        WarriorTimerImg.fillAmount = 1;
        warriorsCount += 1;
        warriorTimer = -2;
        PlaySound(warriorsSound);
    }

    peasantButton.interactable = (wheatCount >= 4 && peasantTimer <= -1);
    warriorButton.interactable = (wheatCount >= 8 && warriorTimer <= -1);

    if (warriorsCount < 0)
    {
        warriorsCount = 0;
        GameOverBack.SetActive(true);
        Time.timeScale = 0;
    }
    if (wheatCount >= wheatForWin)
    {
        WinBack.SetActive(true);
        Time.timeScale = 0;
    }
}

        
    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }



    public void CreateWarrior()
    {
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount +"\n" + warriorsCount +"\n\n" + wheatCount;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        audioSource.mute = !soundEnabled;
        soundButtText.text = soundEnabled ? "ВКЛ" : "ВЫКЛ";
    }

    private void PlaySound(AudioClip clip)
    {
        if(soundEnabled && clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    
    }
}