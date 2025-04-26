using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class VoiceLineController : MonoBehaviour
{
    private EventInstance VoiceLine_1;

    [SerializeField] private EventReference Effect1;

    // Add a public float/int to control the filter (0-100 typically)
    [Range(0, 100)]
    public int FilterAmount = 0;

    // Name of the parameter in FMOD (must match exactly the parameter in the FMOD event)
    [SerializeField] private string FilterParameterName = "FilterAmount";

    public void Start()
    {
        VoiceLine_1 = Audiomanager.instance.PlaySound(Effect1, transform.position);

        // Set initial filter amount
        SetFilter(FilterAmount);
    }

    private void Update()
    {
        // Optional: If you want it to update live when FilterAmount changes
        SetFilter(FilterAmount);
    }

    public void SetFilter(float amount)
    {
        if (VoiceLine_1.isValid())
        {
            VoiceLine_1.setParameterByName(FilterParameterName, amount);
        }
    }

    private void OnDestroy()
    {
        if (VoiceLine_1.isValid())
        {
            VoiceLine_1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            VoiceLine_1.release();
        }
    }
}
