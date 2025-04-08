using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JukeBox : Interactable
{
    EventInstance musicInstance;
    [SerializeField] private EventReference Jukebox1;
    [SerializeField] private EventReference Jukebox2;
    [SerializeField] private EventReference Jukebox3;

    public Mixer_FMOD MixerMod;
    public static float VOLOFF = 0.0f;
    public static float VOLON = 0.5f;
    public int SwitchCount = 1;

    public void Awake()
    {
        MixerMod = GetComponent<Mixer_FMOD>();   
    }

    public void Start()
    {
        Audiomanager.instance.PlayOneShot(Jukebox1, transform.position);
    }

    public override void Interacted()
    {
        SwitchCount = SwitchCount + 1;

        if (SwitchCount == 1)
        {
            MixerMod.JukeboxVol1 = VOLON;
            Audiomanager.instance.PlayOneShot(Jukebox1, transform.position);
            MixerMod.JukeboxVol2 = VOLOFF;
            MixerMod.JukeboxVol3 = VOLOFF;
        }
        else if (SwitchCount == 2)
        {
            MixerMod.JukeboxVol2 = VOLON;
            Audiomanager.instance.PlayOneShot(Jukebox2, transform.position);
            MixerMod.JukeboxVol1 = VOLOFF;
            MixerMod.JukeboxVol3 = VOLOFF;
        }
        else if (SwitchCount == 3)
        {
            MixerMod.JukeboxVol3 = VOLON;
            Audiomanager.instance.PlayOneShot(Jukebox3, transform.position);
            MixerMod.JukeboxVol1 = VOLOFF;
            MixerMod.JukeboxVol2 = VOLOFF;
            SwitchCount = 0;
        }

    }
}
