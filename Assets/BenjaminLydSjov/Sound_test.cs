using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Sound_test : MonoBehaviour
{
    EventInstance musicInstance;
    [SerializeField] private EventReference SFXBALL;
    [SerializeField] private EventReference SFXBALL2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Audiomanager.instance.PlayOneShot(SFXBALL, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Audiomanager.instance.PlayOneShot(SFXBALL2, transform.position);
        }
    }
}
