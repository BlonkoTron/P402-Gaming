using FMODUnity;
using UnityEngine;

public class NPC_Soundmanager : MonoBehaviour
{
    [SerializeField] private EventReference SFXBALL;
    [SerializeField] private EventReference SFXBALL2;
    [SerializeField] private EventReference SFXBALL3;

    public static NPC_Soundmanager Instance_sound;
    InkDialogue inkDialogues;
    public string NPC_Dialog1;
    public string NPC_Dialog2;
    public string NPC_Dialog3;
    public void storys()
    {
        inkDialogues = GetComponent<InkDialogue>();
        inkDialogues.story.BindExternalFunction(NPC_Dialog1, (string soundName) =>
        {
            Audiomanager.instance.PlayOneShot(SFXBALL, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog2, (string soundName2) =>
        {
            Debug.Log(soundName2);
            Audiomanager.instance.PlayOneShot(SFXBALL2, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog3, (string soundName3) =>
        {
            Debug.Log(soundName3);
            Audiomanager.instance.PlayOneShot(SFXBALL3, transform.position);
        });
    }
}
