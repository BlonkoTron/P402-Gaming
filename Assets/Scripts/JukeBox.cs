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
    public int SwitchCount = 2;

    private bool StartJuke2 = false;
    private bool StartJuke3 = false;
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
            MixerMod.JukeboxVol2 = VOLOFF;
            MixerMod.JukeboxVol3 = VOLOFF;
        }
        else if (SwitchCount == 2)
        {
            if (StartJuke2 == false)
            {
                Audiomanager.instance.PlayOneShot(Jukebox2, transform.position);
                StartJuke2 = true; 
            }
            MixerMod.JukeboxVol1 = VOLOFF;
            MixerMod.JukeboxVol2 = VOLON;
            MixerMod.JukeboxVol3 = VOLOFF;
        }
        else if (SwitchCount == 3)
        {
            if (StartJuke3 == false)
            {
                Audiomanager.instance.PlayOneShot(Jukebox3, transform.position);
                StartJuke3 = true;
            }
            MixerMod.JukeboxVol1 = VOLOFF;
            MixerMod.JukeboxVol2 = VOLOFF;
            MixerMod.JukeboxVol3 = VOLON;
            SwitchCount = 0;
        }

    }
}
