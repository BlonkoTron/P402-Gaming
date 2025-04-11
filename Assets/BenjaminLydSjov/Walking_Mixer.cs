using UnityEngine;

public class Walking_Mixer : MonoBehaviour
{
    FMOD.Studio.Bus Walking;
    public float WalkingVol = 1.0f;

    private void Awake()
    {
        Walking = FMODUnity.RuntimeManager.GetBus("bus:/Master/WalkWood");
    }

    void Update()
    {
        Walking.setVolume(WalkingVol);
    }

    public void WoodVol(float NewWoodVOL)
    {
        WalkingVol = NewWoodVOL;
    }
}
