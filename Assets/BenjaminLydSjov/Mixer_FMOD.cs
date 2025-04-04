using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer_FMOD : MonoBehaviour
{
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    FMOD.Studio.Bus Master;
    public float MusicVolume = 0.5f;
    public float SFXVolume = 0.5f;
    public float MasterVolume = 1f;

    private void Awake()
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }
    void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        Master.setVolume(MasterVolume);
    }

    public void MasterVOL(float NewMasterVOL)
    {
        MasterVolume = NewMasterVOL;
    }

    public void MusicVOL(float NewMusicVOL)
    {
        MusicVolume = NewMusicVOL;
    }

    public void SFXVOL(float NewSFXVOL)
    {
        SFXVolume = NewSFXVOL;
    }
}

