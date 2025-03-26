using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class HarvestTimer : MonoBehaviour
{
    public float MaxTime;
    public  bool Tick;
    private AudioSource harvest;

    private Image img;
    private float currentTime;

        void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;
        harvest = GetComponent<AudioSource>();
    }

    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            Tick = true;
            currentTime = MaxTime;
            harvest.Play();
        }
        
        img.fillAmount = currentTime/MaxTime;

        
             
    }


    
}
