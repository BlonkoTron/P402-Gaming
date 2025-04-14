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
        // Start and hold the event instance so we can control it
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
    public void SetEffectActive(bool active)
    {
        if (!soundInstance.isValid()) return;

        // Get the channel group
        soundInstance.getChannelGroup(out ChannelGroup channelGroup);

        if (channelGroup.hasHandle())
        {
            int numDSPs;
            channelGroup.getNumDSPs(out numDSPs);

            for (int i = 0; i < numDSPs; i++)
            {
                channelGroup.getDSP(i, out DSP dsp);
                dsp.getInfo(out string name, out uint version, out int channels, out int configWidth, out int configHeight);

                // Replace this with your Lowpass effect name from FMOD Studio
                if (name.Contains("Lowpass"))
                {
                    dsp.setBypass(!active); // true = bypassed (OFF), false = active (ON)
                    break;
                }
            }
        }
    }
}
