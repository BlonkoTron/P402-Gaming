using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer_FMOD : MonoBehaviour
{
    FMOD.Studio.Bus Jukebox1;
    FMOD.Studio.Bus Jukebox2;
    FMOD.Studio.Bus Jukebox3;
    FMOD.Studio.Bus Master;
    public float JukeboxVol1 = 0.5f;
    public float JukeboxVol2 = 0.5f;
    public float JukeboxVol3 = 0.5f;
    public float MasterVol = 1f;

    private void Awake()
    {
        Jukebox1 = FMODUnity.RuntimeManager.GetBus("bus:/Master/Jukebox1");
        Jukebox2 = FMODUnity.RuntimeManager.GetBus("bus:/Master/Jukebox2");
        Jukebox3 = FMODUnity.RuntimeManager.GetBus("bus:/Master/Jukebox3");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    void Update()
    {
        Jukebox1.setVolume(JukeboxVol1);
        Jukebox2.setVolume(JukeboxVol2);
        Jukebox3.setVolume(JukeboxVol3);
        Master.setVolume(MasterVol);
    }

    public void MasterVOL(float NewMasterVOL)
    {
        JukeboxVol1 = NewMasterVOL;
    }

    public void MusicVOL(float NewMusicVOL)
    {
        JukeboxVol2 = NewMusicVOL;
    }

    public void SFXVOL(float NewSFXVOL)
    {
        JukeboxVol3 = NewSFXVOL;
    }
}

