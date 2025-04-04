using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public CinemachineCamera MainCam;

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
    public void SetToMainCam()
    {
        MainCam.Prioritize();
    }
    public void SetToCam(CinemachineCamera cam)
    {
        cam.Prioritize();
    }
}
