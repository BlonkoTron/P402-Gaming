using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Sound_test : MonoBehaviour
{
    EventInstance musicInstance;
    [SerializeField] private EventReference SFXBALL;
    [SerializeField] private EventReference SFXBALL2;

    public void Audio1()
    {
        Audiomanager.instance.PlayOneShot(SFXBALL, transform.position);
    }

    public void Audio2()
    {
        Audiomanager.instance.PlayOneShot(SFXBALL2, transform.position);
    }
}
