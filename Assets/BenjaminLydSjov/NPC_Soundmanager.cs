using FMODUnity;
using UnityEngine;

public class NPC_Soundmanager : MonoBehaviour
{
    [SerializeField] private EventReference VoiceLine_1;
    [SerializeField] private EventReference VoiceLine_2;
    [SerializeField] private EventReference VoiceLine_3;
    [SerializeField] private EventReference VoiceLine_4;
    [SerializeField] private EventReference VoiceLine_5;
    [SerializeField] private EventReference Achievement;

    public static NPC_Soundmanager Instance_sound;
    InkDialogue inkDialogues;
    public string NPC_Dialog1;
    public string NPC_Dialog2;
    public string NPC_Dialog3;
    public string NPC_Dialog4;
    public string NPC_Dialog5;
    public string AchievementName;
    public void storys()
    {
        inkDialogues = GetComponent<InkDialogue>();
        inkDialogues.story.BindExternalFunction(NPC_Dialog1, (string soundName) =>
        {
            Audiomanager.instance.PlayOneShot(VoiceLine_1, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog2, (string soundName2) =>
        {
            Debug.Log(soundName2);
            Audiomanager.instance.PlayOneShot(VoiceLine_2, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog3, (string soundName3) =>
        {
            Debug.Log(soundName3);
            Audiomanager.instance.PlayOneShot(VoiceLine_3, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog4, (string soundName4) =>
        {
            Debug.Log(soundName4);
            Audiomanager.instance.PlayOneShot(VoiceLine_4, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog5, (string soundName5) =>
        {
            Debug.Log(soundName5);
            Audiomanager.instance.PlayOneShot(VoiceLine_5, transform.position);
        });
        inkDialogues.story.BindExternalFunction(AchievementName, (string Achievements) =>
        {
            Debug.Log(Achievements);
            Audiomanager.instance.PlayOneShot(Achievement, transform.position);
        });
    }
}
