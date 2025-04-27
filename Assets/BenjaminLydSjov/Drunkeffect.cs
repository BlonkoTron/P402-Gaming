using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Drunkeffect : MonoBehaviour
{
    private EventInstance RingEar_Event;
    public GameObject playerpos;

    [SerializeField] private EventReference RingingEar;
    [SerializeField] private EventReference Blurr;
    [SerializeField] private EventReference Slowspeach;
    [SerializeField] private EventReference Wobble;
    
    // Add a public float/int to control the filter (0-100 typically)
    [Range(0, 100)]
    public int RingEarAmount = 0;
    public int BlurrAmount = 0;
    public int SlowspeachAmount = 0;
    public int WobbleAmount = 0;

    // Name of the parameter in FMOD (must match exactly the parameter in the FMOD event) TBN = To be named
    [SerializeField] private string EarringParameterName = "RingEar";
    [SerializeField] private string BlurrParameterName = "TBN";
    [SerializeField] private string SlowspeachParameterName = "TBN";
    [SerializeField] private string WobbleParameterName = "TBN";

    public void Start()
    {
        RingEar_Event = Audiomanager.instance.PlaySound(RingingEar,transform.position);

        // Set initial filter amount
        SetFilter(RingEarAmount);
        SetFilter(BlurrAmount);
        SetFilter(SlowspeachAmount);
        SetFilter(WobbleAmount);
    }

    private void Update()
    {
        SetFilter(RingEarAmount);

        if (RingEar_Event.isValid())
        {
            // Update the position to follow the player
            RingEar_Event.set3DAttributes(RuntimeUtils.To3DAttributes(playerpos.transform.position));
        }
    }

    public void SetFilter(float amount)
    {
        if (RingEar_Event.isValid())
        {
            RingEar_Event.setParameterByName(EarringParameterName, amount);
        }
    }

    private void OnDestroy()
    {
        if (RingEar_Event.isValid())
        {
            RingEar_Event.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            RingEar_Event.release();
        }
    }
}
