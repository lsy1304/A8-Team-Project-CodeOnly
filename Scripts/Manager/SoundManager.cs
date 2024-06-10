using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource[] audioSourcesEffects;
    public AudioSource audioSourcesBgm;

    public Sound[] effectsSound;
    public Sound[] bgmSounds;

    public string[] playSoundName;

    protected override void Awake()
    {
        base.Awake();

        playSoundName = new string[audioSourcesEffects.Length]; //이펙트 숫자만큼 생성
        audioSourcesBgm.volume = 0.5f;
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].volume = 0.5f;
        }
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourcesBgm.clip = bgmSounds[i].clip;
                audioSourcesBgm.Play();
                return;
            }
        }
    }
    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectsSound.Length; i++)
        {
            if (_name == effectsSound[i].name)
            {
                for (int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    if (!audioSourcesEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectsSound[i].name;
                        audioSourcesEffects[j].clip = effectsSound[i].clip;
                        audioSourcesEffects[j].PlayOneShot(effectsSound[i].clip);
                        return;
                    }
                }
                return;
            }
        }
    }

    public void ToggleBGM()
    {
        audioSourcesBgm.mute = !audioSourcesBgm.mute;
    }
    public void ToggleSFX()
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].mute = !audioSourcesEffects[i].mute;
        }
    }

    public void BGMVolume(float _volume)
    {
        audioSourcesBgm.volume = _volume;
       
    }

    public void SFXVolume(float _volume)
    {
        for (int i = 0; i< audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].volume = _volume;
        }
    }

    public void Pause()
    {
        audioSourcesBgm.Pause();
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].mute = true;
        }
    }
    public void UnPause()
    {
        audioSourcesBgm.UnPause();
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].mute = false;
        }
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].Stop();
        }
    }
    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourcesEffects[i].Stop();
                break;
            }

        }
    }

    public void StopBgm(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourcesBgm.clip = bgmSounds[i].clip;
                audioSourcesBgm.Stop();
                return;
            }
        }
    }
}



