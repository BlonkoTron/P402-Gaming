using UnityEngine;
using UnityEngine.Rendering;

public class DrunkVisionController : MonoBehaviour
{
    public static DrunkVisionController Instance;
    


    private Volume ppVolume;



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

    public void UpdateDrunkVision(float bac)
    {

    }


}
