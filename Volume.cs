using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private float volume;
    public Slider slider;
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", .5f);
        slider.value = volume;
    }

    public void SetVolume()
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        AudioListener.volume = volume;
    }
}
