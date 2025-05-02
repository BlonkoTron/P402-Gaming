using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Drunkeffect : MonoBehaviour
{
    public static Drunkeffect Instance;

    private EventInstance RingEar_Event;
    private EventInstance Blurr_Event;
    private EventInstance Slowspeach_Event;
    private EventInstance Wobble_Event;

    public GameObject playerpos;
    public float Drinkamounts; 

    [SerializeField] private EventReference RingingEar;
    [SerializeField] private EventReference Blurr;
    [SerializeField] private EventReference Slowspeach;
    [SerializeField] private EventReference Wobble;

    [Range(0, 100)] public int RingEarAmount = 0;
    [Range(0, 100)] public int BlurrAmount = 0;
    [Range(0, 100)] public int SlowspeachAmount = 0;
    [Range(0, 100)] public int WobbleAmount = 0;

    [SerializeField] private string EarringParameterName = "RingEar";
    [SerializeField] private string BlurrParameterName = "Blurr";
    [SerializeField] private string SlowspeachParameterName = "Slowspeach";
    [SerializeField] private string WobbleParameterName = "Wobble";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
        public void Start()
    {
        RingEar_Event = Audiomanager.instance.PlaySound(RingingEar, transform.position);
        Blurr_Event = Audiomanager.instance.PlaySound(Blurr, transform.position);
        Slowspeach_Event = Audiomanager.instance.PlaySound(Slowspeach, transform.position);
        Wobble_Event = Audiomanager.instance.PlaySound(Wobble, transform.position);

        // Set initial parameters
        SetFilter(RingEar_Event, EarringParameterName, RingEarAmount);
        SetFilter(Blurr_Event, BlurrParameterName, BlurrAmount);
        SetFilter(Slowspeach_Event, SlowspeachParameterName, SlowspeachAmount);
        SetFilter(Wobble_Event, WobbleParameterName, WobbleAmount);
    }

    public void UpdateDrunkAudio(float bac)
    {
        switch (bac)
        {
            case 0:
                Debug.Log("no alcohol - Bac = " + bac);

                break;

            case float p when (p > 0 && p <= 0.2f):
                Debug.Log("a little drunk - Bac = " + bac);
                RingEarAmount = 0;
                BlurrAmount = 0;
                SlowspeachAmount = 0;
                WobbleAmount = 0;
                break;

            case float p when (p > 0.2f && p <= 0.4f):
                Debug.Log("you are drunk - Bac = " + bac);
                RingEarAmount = 3;
                BlurrAmount = 10;
                SlowspeachAmount = 20;
                WobbleAmount = 20;
                break;

            case float p when (p > 0.4f && p <= 0.8f):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                RingEarAmount = 6;
                BlurrAmount = 20;
                SlowspeachAmount = 50;
                WobbleAmount = 60;
                break;

            case float p when (p > 0.8):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                RingEarAmount = 9;
                BlurrAmount = 30;
                SlowspeachAmount = 70;
                WobbleAmount = 90;
                break;
        }
    }
    private void Update()
    {
        if (RingEar_Event.isValid())
        {
            SetFilter(RingEar_Event, EarringParameterName, RingEarAmount);
            RingEar_Event.set3DAttributes(RuntimeUtils.To3DAttributes(playerpos.transform.position));
        }
        if (Blurr_Event.isValid())
        {
            SetFilter(Blurr_Event, BlurrParameterName, BlurrAmount);
            Blurr_Event.set3DAttributes(RuntimeUtils.To3DAttributes(playerpos.transform.position));
        }
        if (Slowspeach_Event.isValid())
        {
            SetFilter(Slowspeach_Event, SlowspeachParameterName, SlowspeachAmount);
            Slowspeach_Event.set3DAttributes(RuntimeUtils.To3DAttributes(playerpos.transform.position));
        }
        if (Wobble_Event.isValid())
        {
            SetFilter(Wobble_Event, WobbleParameterName, WobbleAmount);
            Wobble_Event.set3DAttributes(RuntimeUtils.To3DAttributes(playerpos.transform.position));
        }
    }

    private void SetFilter(EventInstance instance, string parameterName, float amount)
    {
        if (instance.isValid())
        {
            instance.setParameterByName(parameterName, amount);
        }
    }

    private void OnDestroy()
    {
        StopAndRelease(RingEar_Event);
        StopAndRelease(Blurr_Event);
        StopAndRelease(Slowspeach_Event);
        StopAndRelease(Wobble_Event);
    }

    private void StopAndRelease(EventInstance instance)
    {
        if (instance.isValid())
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }
    }
    //getwobble 
    public int GetWobbleAmount()
    {
        return WobbleAmount;
    }

    public int GetBlurrAmount()
    {
        return BlurrAmount;
    }

    public int GetSlowspeachAmount()
    {
        return SlowspeachAmount;
    }
}
