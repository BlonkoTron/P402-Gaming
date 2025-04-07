using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JukeBox : Interactable
{
    EventInstance musicInstance;
    [SerializeField] private EventReference SFXBALL;
    [SerializeField] private EventReference SFXBALL2;

    private void Awake()
    {
        Audiomanager.instance.PlayOneShot(SFXBALL, transform.position);
    }
    public override void Interacted()
    {
        //Audiomanager.instance.PlayOneShot(SFXBALL2, transform.position);
    }
}
