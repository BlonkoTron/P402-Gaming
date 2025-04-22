using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkVisionController : MonoBehaviour
{
    public static DrunkVisionController Instance;
    


    private Volume ppVolume;
    private MotionBlur mBlur;
    private Bloom bloom;
    private LensDistortion lensD;
    private ChromaticAberration chromA;

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

        ppVolume = GetComponent<Volume>();
        ppVolume.profile.TryGet(out mBlur);
        ppVolume.profile.TryGet(out bloom);
        ppVolume.profile.TryGet(out lensD);
        ppVolume.profile.TryGet(out chromA);

        mBlur.intensity.value = 0;
        bloom.intensity.value = 0;
        lensD.intensity.value = 0;
        chromA.intensity.value = 0;
        
    }

    public void UpdateDrunkVision(float bac)
    {
        switch (bac)
        {
            case 0:
                Debug.Log("no alcohol - Bac = " + bac);

                break;

            case float n when (n > 0 && n <= 0.2f):
                Debug.Log("a little drunk - Bac = " + bac);
                mBlur.intensity.value = 0.10f;
                bloom.intensity.value = 0.2f;
                lensD.intensity.value = -0.05f;
                break;

            case float n when (n > 0.2f && n <= 0.4f):
                Debug.Log("you are drunk - Bac = " + bac);
                mBlur.intensity.value = 0.3f;
                bloom.intensity.value = 0.5f;
                lensD.intensity.value = -0.4f;
                chromA.intensity.value = 5;
                break;

            case float n when (n > 0.4f && n <= 0.6f):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                mBlur.intensity.value = 0.45f;
                bloom.intensity.value = 0.75f;
                lensD.intensity.value = -0.6f;
                chromA.intensity.value = 15;
                break;

            case float n when (n > 0.8):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                mBlur.intensity.value = 0.6f;
                bloom.intensity.value = 1;
                lensD.intensity.value = -0.8f;
                chromA.intensity.value = 20;
                break;
        }
    }


}
