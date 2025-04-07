using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public CinemachineCamera MainCam;

    [SerializeField] private CinemachineCamera npcCam;

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

        npcCam.Priority = MainCam.Priority - 1;
        MainCam.Prioritize();
        activeCam = MainCam;
    }
    public void SetToCam(CinemachineCamera cam)
    {
        cam.Prioritize();
        activeCam = cam;
    }

    public void SetToNpcCam(Transform target)
    {
        npcCam.LookAt = target;
        npcCam.Priority = MainCam.Priority + 1;
        npcCam.Prioritize();
        activeCam = npcCam;

    }

}
