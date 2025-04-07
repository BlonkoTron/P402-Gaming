using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public CinemachineCamera MainCam;

    public CinemachineCamera activeCam;
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
        SetToMainCam();
    }
    private void Start()
    {
        activeCam = MainCam;
    }
    public void SetToMainCam()
    {
        MainCam.Prioritize();
        activeCam = MainCam;
    }
    public void SetToCam(CinemachineCamera cam)
    {
        cam.Prioritize();
        activeCam = cam;
    }

    public void LookAtMe(Vector3 pos)
    {
        
    }

}
