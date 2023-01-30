using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup SFXGroup;

    public SliderObject musicSlider;
    public SliderObject SFXSlider;

    public Sprite[] volumeIconSprite;

    // Start is called before the first frame update
    /// <summary>
    /// A quick way to set the volume sliders like the sound.
    /// </summary>
    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.volumeSlider.value = musicVolume;
        SFXSlider.volumeSlider.value = SFXVolume;

        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    /// <summary>
    /// Function that will be called with the slider On Value Changed function.
    /// Will set the volume of the music mixer group to the sliders value and change the icon to match the volume amount.
    /// </summary>
    public void ChangeMusicVolume()
    {
        float sliderValue = musicSlider.volumeSlider.value;

        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        if (sliderValue < 0.25f)
        {
            musicSlider.volumeImage.sprite = volumeIconSprite[3];
        }
        else if (sliderValue < 0.5f)
        {
            musicSlider.volumeImage.sprite = volumeIconSprite[2];
        }
        else if (sliderValue < 0.75f)
        {
            musicSlider.volumeImage.sprite = volumeIconSprite[1];
        }
        else
        {
            musicSlider.volumeImage.sprite = volumeIconSprite[0];
        }
    }

    /// <summary>
    /// Function that will be called with the slider On Value Changed function.
    /// Will set the volume of the SFX mixer group to the sliders value and change the icon to match the volume amount.
    /// </summary>
    public void ChangeSFXVolume()
    {
        float sliderValue = SFXSlider.volumeSlider.value;

        SFXGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        if (sliderValue < 0.25f)
        {
            SFXSlider.volumeImage.sprite = volumeIconSprite[3];
        }
        else if (sliderValue < 0.5f)
        {
            SFXSlider.volumeImage.sprite = volumeIconSprite[2];
        }
        else if (sliderValue < 0.75f)
        {
            SFXSlider.volumeImage.sprite = volumeIconSprite[1];
        }
        else
        {
            SFXSlider.volumeImage.sprite = volumeIconSprite[0];
        }
    }

    /// <summary>
    /// Class for all the slider variables
    /// </summary>
    [Serializable]
    public class SliderObject
    {
        public Image volumeImage;
        public Slider volumeSlider;
    }
}
