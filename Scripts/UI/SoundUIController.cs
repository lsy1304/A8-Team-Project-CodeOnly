using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public Slider bgmSlider, sfxSldier;
    public GameObject mainBoard , bgmVImage, sfxVImage;

    private void Start()
    {
        bgmSlider.value = SoundManager.Instance.audioSourcesBgm.volume;
        for (int i = 0; i < SoundManager.Instance.audioSourcesEffects.Length; ++i)
        {
            sfxSldier.value = SoundManager.Instance.audioSourcesEffects[i].volume;
        }
    }


    public void ToggleBgm()
    {
        SoundManager.Instance.ToggleBGM();
        bool isActive = bgmVImage.activeSelf;
        bgmVImage.SetActive(!isActive);

    }
    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
        bool isActive = sfxVImage.activeSelf;
        sfxVImage.SetActive(!isActive);
    }

    public void BGM_Volume()
    {
        SoundManager.Instance.BGMVolume(bgmSlider.value);
    }
    public void SFX_Volume()
    {
        SoundManager.Instance.SFXVolume(sfxSldier.value);
    }

    public void ToggleWindow()
    {
        bool isActive = mainBoard.activeSelf;
        mainBoard.SetActive(!isActive);
    }

}
