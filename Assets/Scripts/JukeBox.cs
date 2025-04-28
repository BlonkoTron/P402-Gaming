using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JukeBox : Interactable
{

    private EventInstance Juke1_song;
    private EventInstance Juke2_song;
    private EventInstance Juke3_song;

    EventInstance musicInstance;
    [SerializeField] private EventReference Jukebox1;
    [SerializeField] private EventReference Jukebox2;
    [SerializeField] private EventReference Jukebox3;

    public int SwitchCount = 1;

    public void Start()
    {
        Juke1_song = Audiomanager.instance.PlaySound(Jukebox1, transform.position);
    }

    public override void Interacted()
    {
        Debug.Log("YAH");
        SwitchCount = SwitchCount + 1;

        if (SwitchCount == 1)
        {
            Juke1_song = Audiomanager.instance.PlaySound(Jukebox1, transform.position);
            Audiomanager.instance.StopSound(Juke2_song);
            Audiomanager.instance.StopSound(Juke3_song);
        }
        else if (SwitchCount == 2)
        {
            Juke2_song = Audiomanager.instance.PlaySound(Jukebox2, transform.position);
            Audiomanager.instance.StopSound(Juke1_song);
            Audiomanager.instance.StopSound(Juke3_song);
        }
        else if (SwitchCount == 3)
        {
            Juke3_song = Audiomanager.instance.PlaySound(Jukebox3, transform.position);
            Audiomanager.instance.StopSound(Juke1_song);
            Audiomanager.instance.StopSound(Juke2_song);

            SwitchCount = 0; 
        }

    }
        private void OnDestroy()
    {
        Audiomanager.instance.StopSound(Juke1_song);
        Audiomanager.instance.StopSound(Juke2_song);
        Audiomanager.instance.StopSound(Juke3_song);
    }
}
