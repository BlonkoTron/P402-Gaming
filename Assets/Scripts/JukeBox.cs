using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JukeBox : Interactable
{
    EventInstance musicInstance;
    [SerializeField] private EventReference Jukebox1;
    [SerializeField] private EventReference Jukebox2;

    Mixer_FMOD MixerMod;
    public float VOLON = 0.0f;

    public void Awake()
    {
        MixerMod = GetComponent<Mixer_FMOD>();
    }

    public override void Interacted()
    {
        Audiomanager.instance.PlayOneShot(Jukebox1, transform.position);
        MixerMod.test = 1.0f;
    }
}
