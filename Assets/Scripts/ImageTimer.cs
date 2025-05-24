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
    private bool TickSound = false;

    void Start()
    {
        img = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("audioSource нету на" + gameObject.name, gameObject);
        }

        currentTime = MaxTime * 0.99f;
    }

    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (TickSound)
            {
                Tick = true;
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
            TickSound = true;
            currentTime = MaxTime;
        }

        img.fillAmount = Mathf.Clamp01(currentTime / MaxTime);
    }

        public void ResetTimer()
    {
        currentTime = 0;
        Tick = false;
    }
}