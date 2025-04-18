using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;

public class Occlusion : MonoBehaviour
{
    [SerializeField] 
    
    private EventReference ChooseAudio;
    [SerializeField]
    private EventInstance Sound;
    private EventDescription SoundDescription; 
    private StudioListener Listener;
    private PLAYBACK_STATE PBS;

    [SerializeField]
    [Range(0f, 5f)]
    private float SoundOcclusionWidth = 1f;
    [SerializeField]
    private LayerMask OcclusionLayerMask;
    [SerializeField]
    [Range(0f, 15f)]
    private float MaxDistance = 15f;
    private bool AudioIsVirtual;
    private float DistanceToListener = 0f;
    private float linecastHitCount;
    private Color rayColor; 

    
    private void Start()
    {
        Sound = RuntimeManager.CreateInstance(ChooseAudio);
        RuntimeManager.AttachInstanceToGameObject(Sound, transform, GetComponent<Rigidbody>());
        Sound.start();
        Sound.release();

        SoundDescription = RuntimeManager.GetEventDescription(ChooseAudio);
        SoundDescription.getMinMaxDistance(out float min, out float max);
        
        Listener = FindFirstObjectByType<StudioListener>();
        
    }

    private void FixedUpdate()
    {
        Sound.isVirtual(out AudioIsVirtual);
        Sound.getPlaybackState(out PBS);
        DistanceToListener = Vector3.Distance(Listener.transform.position, transform.position);

        if (DistanceToListener > MaxDistance)
        {
            if (PBS == PLAYBACK_STATE.PLAYING)
            {
                Sound.setPaused(true); // Pause the sound when out of range
            }
            return; // Exit the method to avoid further calculations
        }

        if (DistanceToListener <= MaxDistance)
        {
            if (PBS == PLAYBACK_STATE.PLAYING || PBS == PLAYBACK_STATE.STOPPED)
            {
                Sound.setPaused(false); // Resume the sound when back in range
            }
        }

        if (!AudioIsVirtual && PBS == PLAYBACK_STATE.PLAYING)
        {
            OcclusionCalcaulation(transform.position, Listener.transform.position);
        }

        linecastHitCount = 0f;
    }

    private void OcclusionCalcaulation(Vector3 sound, Vector3 listener)
    {
       Vector3 SoundLeft = CalculatePoint (sound, listener, SoundOcclusionWidth, true);
       Vector3 SoundRight = CalculatePoint (sound, listener, SoundOcclusionWidth, false);

       Vector3 ListenLeft = CalculatePoint (sound, listener, SoundOcclusionWidth, true);
       Vector3 ListenRight = CalculatePoint (sound, listener, SoundOcclusionWidth, true);

      
       CastLine(SoundLeft, ListenLeft);
       CastLine(SoundLeft, listener);
       CastLine(SoundLeft, ListenRight);

       CastLine(SoundRight, ListenLeft);
       CastLine(SoundRight, listener);
       CastLine(SoundRight, ListenRight);
       
       CastLine(sound, ListenLeft);
       CastLine(sound, listener);
       CastLine(sound, ListenRight); 

       

        if(SoundOcclusionWidth == 0)
        {
            Color rayColor = Color.blue;
        }
        else 
        {
            Color rayColor = Color.green; 
        }

        SetParameter();
      
    }
    
    private Vector3 CalculatePoint(Vector3 a, Vector3 b, float m, bool PositiveOrNegative)
    {
        float x;
        float z;
        float n = Vector3.Distance(new Vector3(a.x, 0f, a.z), new Vector3(b.x, 0f, b.z));
        float mn = m / n;
        if(PositiveOrNegative)
        {
            x = a.x + (mn*(a.x - b.x));
            z = a.z - (mn*(a.z - b.z));

        }
        else
        {
            x = a.x - (mn*(a.x - b.x));
            z = a.z + (mn*(a.z - b.z));
        }
        return new Vector3(x, a.y, z);

    }
    
    private void CastLine(Vector3 Start, Vector3 End)
    {
        RaycastHit hit;
        if(Physics.Linecast(Start, End, out hit, OcclusionLayerMask))
        {
            linecastHitCount++;
            rayColor = Color.blue;
        }
        else
        {
            rayColor = Color.green;
        }
        UnityEngine.Debug.DrawLine(Start, End, rayColor, 0.1f);
    }   

    private void SetParameter()
    {
       Sound.setParameterByName("Occlusion", linecastHitCount/9, true);
    }

}



