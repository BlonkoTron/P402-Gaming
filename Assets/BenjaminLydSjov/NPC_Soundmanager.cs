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

    private Drunkeffect drunkEffect;

    InkDialogue inkDialogues;
    public string NPC_Dialog1;
    public string NPC_Dialog2;
    public string NPC_Dialog3;
    public string NPC_Dialog4;
    public string NPC_Dialog5;

    [SerializeField] private bool nerdCamShift;
    [SerializeField] private Transform nerd1;
    [SerializeField] private Transform nerd2;

    private void Start()
    {
        drunkEffect = FindObjectOfType<Drunkeffect>();
    }

    public void storys()
    {
        inkDialogues = GetComponent<InkDialogue>();

        inkDialogues.story.BindExternalFunction(NPC_Dialog1, (string NPC_Dialog1) =>
        {
            VoiceLine_1 = Audiomanager.instance.PlaySound(AudioLine_1, transform.position);
            SetWobble(VoiceLine_1);
            SetBlurr(VoiceLine_1);
            Setslowspeech(VoiceLine_1);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog2, (string NPC_Dialog2) =>
        {
            VoiceLine_2 = Audiomanager.instance.PlaySound(AudioLine_2, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_1);
            SetWobble(VoiceLine_2);
            SetBlurr(VoiceLine_2);
            Setslowspeech(VoiceLine_2);
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog3, (string NPC_Dialog3) =>
        {
            VoiceLine_3 = Audiomanager.instance.PlaySound(AudioLine_3, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_2);
            SetWobble(VoiceLine_3);
            SetBlurr(VoiceLine_3);
            Setslowspeech(VoiceLine_3);

            if (nerdCamShift)
            {
                CameraController.Instance.SetToNpcCam(nerd2);
            }
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog4, (string NPC_Dialog4) =>
        {
            VoiceLine_4 = Audiomanager.instance.PlaySound(AudioLine_4, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_3);
            SetWobble(VoiceLine_4);
            SetBlurr(VoiceLine_4);
            Setslowspeech(VoiceLine_4);

            if (nerdCamShift)
            {
                CameraController.Instance.SetToNpcCam(nerd1);
            }
        });

        inkDialogues.story.BindExternalFunction(NPC_Dialog5, (string NPC_Dialog5) =>
        {
            VoiceLine_5 = Audiomanager.instance.PlaySound(AudioLine_5, transform.position);
            Audiomanager.instance.StopSound(VoiceLine_4);
            SetWobble(VoiceLine_5);
            SetBlurr(VoiceLine_5);
            Setslowspeech(VoiceLine_5);
        });
    }

    private void SetWobble(EventInstance instance)
    {
        if (instance.isValid() && drunkEffect != null)
        {
            instance.setParameterByName("Wobble", drunkEffect.GetWobbleAmount());
        }
    }

    private void SetBlurr(EventInstance instance2)
    {
        if (instance2.isValid() && drunkEffect != null)
        {
            instance2.setParameterByName("Blurr", drunkEffect.GetBlurrAmount());
        }
    }

    private void Setslowspeech(EventInstance instance3)
    {
        if (instance3.isValid() && drunkEffect != null)
        {
            instance3.setParameterByName("Slowspeach", drunkEffect.GetSlowspeachAmount());
        }
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
