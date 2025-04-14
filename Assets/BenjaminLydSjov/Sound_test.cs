using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using FMOD;

public class Sound_test : MonoBehaviour
{
    private EventInstance soundInstance;
    [SerializeField] private EventReference SFXBALL;

    private void Start()
    {
        // Start and hold the event instance so it can be controlled
        soundInstance = RuntimeManager.CreateInstance(SFXBALL);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        soundInstance.start();
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SetEffectActive(false);
        }

        if (Input.GetKeyDown("c"))
        {
            SetEffectActive(true);
        }

    }
    //Sets a global bool which turns the effect ON/off
    public void SetEffectActive(bool active)
    {
        //If the sound i valid we continue, if not we go back to prevent errors.
        if (!soundInstance.isValid()) return;

        // Get the channel group from FMOD. This is the default group for the track.
        soundInstance.getChannelGroup(out ChannelGroup channelGroup);

        //checks if the channel group is valid, to avoid crashes
        if (channelGroup.hasHandle())
        {
            // we loop through the channelgroup for the sound. Then we see how many SFX are attached to it. 
            int numDSPs;
            channelGroup.getNumDSPs(out numDSPs);

            //then it loops thorugh each one. 
            for (int i = 0; i < numDSPs; i++)
            {
                channelGroup.getDSP(i, out DSP dsp);
                //pulls all the data out to find the effects/filters
                dsp.getInfo(out string name, out uint version, out int channels, out int configWidth, out int configHeight);

                // Replace this with your Lowpass effect name from FMOD Studio. if it finds the "lowpass" it can set the effect ON/OFF
                if (name.Contains("Lowpass"))
                {
                    //when the command SetEffectActive(true/false) is called. it activates/deactivates the filter. Breaks in the end for another call. 
                    dsp.setBypass(!active);
                    break;
                }
            }
        }
    }
}
