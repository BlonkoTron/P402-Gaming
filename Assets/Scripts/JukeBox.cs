using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JukeBox : Interactable
{

    private EventInstance Juke1_song;

    EventInstance musicInstance;
    [SerializeField] private EventReference Jukebox1;

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
            Audiomanager.instance.PauseSound(Juke1_song, false);

        }
        if (SwitchCount == 2 )
        {
            Audiomanager.instance.PauseSound(Juke1_song,true);
            SwitchCount = 0;
        }
    }
        private void OnDestroy()
    {
        Audiomanager.instance.StopSound(Juke1_song);
    }
}
