using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class Drunkeffect : MonoBehaviour
{
    //instance of script
    public static Drunkeffect Instance;

    // General Eventinstance for the sounds
    private EventInstance RingEar_Event;
    private EventInstance Blurr_Event;
    private EventInstance Slowspeach_Event;
    private EventInstance Wobble_Event;

    //Playerpos so the ringing ear sfx follows the player. Drinkamount to figure out how drunk the player is. 
    public GameObject playerpos;
    public float Drinkamounts; 

    // Eventrefrence which play the Ringingear sound. The others are 3 are just fillers. 
    [SerializeField] private EventReference RingingEar;
    [SerializeField] private EventReference Blurr;
    [SerializeField] private EventReference Slowspeach;
    [SerializeField] private EventReference Wobble;

    //Range which controls the amount of the audio filters, going from 0-100. These values change the filter amount in FMOD (which also goes form 0-100) 
    [Range(0, 100)] public int RingEarAmount = 0;
    [Range(0, 100)] public int BlurrAmount = 0;
    [Range(0, 100)] public int SlowspeachAmount = 0;
    [Range(0, 100)] public int WobbleAmount = 0;

    //Private strings which gets the name of the filters from FMOD. Then this script can contol them in Unity.
    [SerializeField] private string EarringParameterName = "RingEar";
    [SerializeField] private string BlurrParameterName = "Blurr";
    [SerializeField] private string SlowspeachParameterName = "Slowspeach";
    [SerializeField] private string WobbleParameterName = "Wobble";

    //creates an instance of the script. 
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
    // plays the different audioclips
        public void Start()
    {
        RingEar_Event = Audiomanager.instance.PlaySound(RingingEar, transform.position);
        Blurr_Event = Audiomanager.instance.PlaySound(Blurr, transform.position);
        Slowspeach_Event = Audiomanager.instance.PlaySound(Slowspeach, transform.position);
        Wobble_Event = Audiomanager.instance.PlaySound(Wobble, transform.position);

        // Set initial parameters for the differen filters in FMOD
        SetFilter(RingEar_Event, EarringParameterName, RingEarAmount);
        SetFilter(Blurr_Event, BlurrParameterName, BlurrAmount);
        SetFilter(Slowspeach_Event, SlowspeachParameterName, SlowspeachAmount);
        SetFilter(Wobble_Event, WobbleParameterName, WobbleAmount);
    }

    //This script sets the different values, according to how much the player have been drinking. The higher the BAC (blood alchohol level) The higher the filters become.
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
                RingEarAmount = 4;
                BlurrAmount = 15;
                SlowspeachAmount = 15;
                WobbleAmount = 25;
                break;

            case float p when (p > 0.4f && p <= 0.8f):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                RingEarAmount = 7;
                BlurrAmount = 20;
                SlowspeachAmount = 20;
                WobbleAmount = 50;
                break;

            case float p when (p > 0.8):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                RingEarAmount = 10;
                BlurrAmount = 37;
                SlowspeachAmount = 37;
                WobbleAmount = 70;
                break;
        }
    }
    //This update changes the filter constant, so if a change occurs it increases or decreases the different filters in FMOD. 
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

    //This function works with the void Update. It sets the parameter for the different filters from FMOD. 
    private void SetFilter(EventInstance instance, string parameterName, float amount)
    {
        if (instance.isValid())
        {
            instance.setParameterByName(parameterName, amount);
        }
    }

    //When changing Scene in unity, the different sounds stop so they dont play in the next scene. 
    private void OnDestroy()
    {
        StopAndRelease(RingEar_Event);
        StopAndRelease(Blurr_Event);
        StopAndRelease(Slowspeach_Event);
        StopAndRelease(Wobble_Event);
    }

    //This void works with the "OnDestory" . it stops the music and releases it. 
    private void StopAndRelease(EventInstance instance)
    {
        if (instance.isValid())
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }
    }
    //These int are used to get the values of the amounts of the filters to other scripts. 
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
