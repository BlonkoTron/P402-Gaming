using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Sound_test : MonoBehaviour
{
    EventInstance musicInstance;
    [SerializeField] private EventReference SFXBALL;
    [SerializeField] private EventReference SFXBALL2;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Audio1();
        }


        if (Input.GetKeyDown("c"))
        {
            Audio2();
        }
    }
    public void Audio1()
    {
        Audiomanager.instance.PlayOneShot(SFXBALL, transform.position);
    }

    public void Audio2()
    {
        Audiomanager.instance.PlayOneShot(SFXBALL2, transform.position);
    }
}
