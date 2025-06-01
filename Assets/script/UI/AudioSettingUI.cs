using UnityEngine;
using UnityEngine.UI;

public class AudioSettingUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        musicSlider.value = Audio.instance.musicVolume;
        sfxSlider.value = Audio.instance.sfxVolume;
    }

    void OnMusicVolumeChanged(float value)
    {
        Audio.instance.SetMusicVolume(value);
    }

    void OnSFXVolumeChanged(float value)
    {
        Audio.instance.SetSFXVolume(value);
    }
}
