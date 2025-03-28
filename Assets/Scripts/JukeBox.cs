using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JukeBox : Interactable
{
    [SerializeField] private AudioClip[] music;
    private int musicIndex = 0;
    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = music[0];
        audioSrc.Play(0);
    }
    public override void Interacted()
    {
        if (musicIndex+1>=music.Length)
        {
            musicIndex=0;
        } else
        {
            musicIndex++;
        }
        audioSrc.clip = music[musicIndex];
        audioSrc.Play(0);
    }
}
