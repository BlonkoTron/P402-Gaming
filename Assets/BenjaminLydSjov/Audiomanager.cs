using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Audiomanager: MonoBehaviour
{
    public static Audiomanager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("NOPE");
            return;
        }
        instance = this;
    }

    // PlayOneShot for SFX
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
