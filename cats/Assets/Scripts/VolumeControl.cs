using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    private Slider slider;

    void Start ()
    {
        slider = gameObject.GetComponentInParent<Slider>();
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void SetVolume ()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", slider.value);
        PlayerPrefs.Save();
    }
}
