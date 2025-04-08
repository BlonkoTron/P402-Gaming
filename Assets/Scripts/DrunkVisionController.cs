using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkVisionController : MonoBehaviour
{
    public static DrunkVisionController Instance;
    


    private Volume ppVolume;
    private MotionBlur mBlur;


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

        Debug.Log(mBlur.ToString());
    }

    public void UpdateDrunkVision(float bac)
    {
        switch (bac)
        {
            case 0:
                Debug.Log("no alcohol - Bac = " + bac);

                

                break;

            case float n when (n > 0 && n <= 0.5f):
                Debug.Log("a little drunk - Bac = " + bac);
                break;

            case float n when (n > 0.5f && n <= 1):
                Debug.Log("you are drunk - Bac = " + bac);
                break;

            case float n when (n > 1 && n <= 1.5f):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                break;

            case float n when (n > 1.5f):
                Debug.Log("pretty fuckin drunk - Bac = " + bac);
                break;
        }
    }


}
