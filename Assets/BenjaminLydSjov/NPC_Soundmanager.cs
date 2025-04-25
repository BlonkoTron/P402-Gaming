using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class NPC_Soundmanager : MonoBehaviour
{

    private EventInstance VoiceLine_1;
    private EventInstance VoiceLine_2;
    private EventInstance VoiceLine_3;
    private EventInstance VoiceLine_4;
    private EventInstance VoiceLine_5;

    [SerializeField] private EventReference AudioLine_1;
    [SerializeField] private EventReference AudioLine_2;
    [SerializeField] private EventReference AudioLine_3;
    [SerializeField] private EventReference AudioLine_4;
    [SerializeField] private EventReference AudioLine_5;

    public static NPC_Soundmanager Instance_sound;

    InkDialogue inkDialogues;
    public string NPC_Dialog1;
    public string NPC_Dialog2;
    public string NPC_Dialog3;
    public string NPC_Dialog4;
    public string NPC_Dialog5;

    [SerializeField] private bool nerdCamShift;
    [SerializeField] private Transform nerd1;
    [SerializeField] private Transform nerd2;

    public void storys()
    {
        inkDialogues = GetComponent<InkDialogue>();
        inkDialogues.story.BindExternalFunction(NPC_Dialog1, (string NPC_Dialog1) =>
        {
            VoiceLine_1 = Audiomanager.instance.PlaySound(AudioLine_1, transform.position);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog2, (string NPC_Dialog2) =>
        {
            VoiceLine_2 = Audiomanager.instance.PlaySound(AudioLine_2, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_1);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog3, (string NPC_Dialog3) =>
        {
            VoiceLine_3 = Audiomanager.instance.PlaySound(AudioLine_3, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_2);

            if (nerdCamShift)
            {
                CameraController.Instance.SetToNpcCam(nerd2);
            }
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog4, (string NPC_Dialog4) =>
        {
            VoiceLine_4 = Audiomanager.instance.PlaySound(AudioLine_4, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_3);

            if (nerdCamShift)
            {
                CameraController.Instance.SetToNpcCam(nerd1);
            }

        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog5, (string NPC_Dialog5) =>
        {
            VoiceLine_5 = Audiomanager.instance.PlaySound(AudioLine_5, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_4);

 
        });
    }

    public void Endstorys()
    {
        Audiomanager.instance.StopSound(VoiceLine_1);
        Audiomanager.instance.StopSound(VoiceLine_2);
        Audiomanager.instance.StopSound(VoiceLine_3);
        Audiomanager.instance.StopSound(VoiceLine_4);
        Audiomanager.instance.StopSound(VoiceLine_5);
    }
}
