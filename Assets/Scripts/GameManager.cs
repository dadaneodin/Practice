using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
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
    public Button restartButton;

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


    private int IntPeasantCount;
    private int IntWarriorsCount;
    private int IntWheatCount;
    private float intRaidMaxTime;
    private int IntNextRaid;

    void Start()
    {
        //дада
        IntPeasantCount = peasantCount;
        IntWarriorsCount = warriorsCount;
        IntWheatCount = wheatCount;
        intRaidMaxTime = raidMaxTime;
        IntNextRaid = nextRaid;


        UpdateText();
        raidTimer = raidMaxTime;
        audioSource = GetComponent<AudioSource>();
        soundButtText.text = soundEnabled ? "ВКЛ" : "ВЫКЛ";
        GameOverBack.SetActive(false);
        PauseMenu.SetActive(false);
        WinBack.SetActive(false);
    }


    void Update()
    {
        // Debug.Log(GetComponent<AudioSource>() !=null);
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

        if (HarvestTimer.Tick && peasantCost > 0)
        {
            wheatCount += peasantCount * wheatPerPeasant;
            if (peasantCount > 0)
                PlaySound(harvestSound);
        }


        if (EatingTimer.Tick && warriorCost > 0)
        {
            wheatCount -= warriorsCount * wheatToWarriors;
            if (warriorsCount > 0)
                PlaySound(eatSound);
        }

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

        // peasantButton.interactable = true;
        // warriorButton.interactable = true;

        peasantButton.interactable = (wheatCount >= peasantCost && peasantTimer <= -1);
        warriorButton.interactable = (wheatCount >= warriorCost && warriorTimer <= -1);

        if (warriorsCount <= 0 && !GameOverBack.activeSelf)
        {
            warriorsCount = 0;
            GameOverBack.SetActive(true);
            Time.timeScale = 0;
        }
        if (wheatCount >= wheatForWin && !WinBack.activeSelf)
        {
            WinBack.SetActive(true);
            Time.timeScale = 0;
        }

        UpdateText();
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

    public void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        soundButtText.text = soundEnabled ? "ВКЛ" : "ВЫКЛ";
        AudioListener.volume = soundEnabled ? 1f : 0f;
    }

    private void PlaySound(AudioClip clip)
    {
        if (soundEnabled && clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + warriorsCount + "\n\n" + wheatCount;
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }



    public void RestartGame()
    {
        //dd
        peasantCount = IntPeasantCount;
        warriorsCount = IntWarriorsCount;
        wheatCount = IntWheatCount;
        raidMaxTime = intRaidMaxTime;
        nextRaid = IntNextRaid;

        //f
        peasantTimer = -2;
        warriorTimer = -2;
        raidTimer = raidMaxTime;

        //f
        if (HarvestTimer != null)
        {
            HarvestTimer.ResetTimer();
        }

        if (EatingTimer != null)
        {
            EatingTimer.ResetTimer();
        }
        //up ui
        UpdateText();
        RaidTimerImg.fillAmount = 1;
        PeasantTimerImg.fillAmount = 1;
        WarriorTimerImg.fillAmount = 1;

        //close back's
        WinBack.SetActive(false);
        GameOverBack.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}