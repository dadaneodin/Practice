using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float MaxTime;
    public bool Tick;
    private AudioSource audioSource;

    private Image img;
    private float currentTime;

    void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;
        audioSource = GetComponent<AudioSource>();
        if(audioSource==null)
        {
            Debug.Log(gameObject.name, gameObject);
        }
    
    }

    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0) {
            Tick = true;
            currentTime = MaxTime;
            if (audioSource !=null) 
            audioSource.Play();
        }
        img.fillAmount = currentTime / MaxTime;
    }
}