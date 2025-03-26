using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class warriorsScript : MonoBehaviour
{
    public float MaxTime;
    public  bool Tick;
    public AudioSource createWarriors;

    private Image img;
    private float currentTime;

        void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;

        createWarriors = GetComponent<AudioSource>();
    }

    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            createWarriors.Play();
            Tick = true;
            currentTime = MaxTime;

        }
        
        img.fillAmount = currentTime/MaxTime;

        
             
    }


    
}
