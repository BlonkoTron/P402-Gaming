using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class DrinkingController : MonoBehaviour
{
    public static DrinkingController Instance;

    public UnityAction OnDrink;

    [HideInInspector] public CinemachineCamera drinkingCam;
    private Animator drinkingCamAnimator;
    public static float bloodAlcoholContent=0;
    [SerializeField] private ParticleSystem pukeParticle;
    [SerializeField] private float[] BACThresholdLevels = new float[3];
    private static int currentThresholdIndex=0;

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
        drinkingCam = GetComponent<CinemachineCamera>();
        drinkingCamAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Puke();
        }

    }

    public void Drink(float amount)
    {
        CameraController.Instance.SetToCam(drinkingCam);
        drinkingCamAnimator.SetTrigger("drink");
        bloodAlcoholContent += amount;
        OnDrink.Invoke();
        DrunkVisionController.Instance.UpdateDrunkVision(bloodAlcoholContent);
        // check if transition to next scene
        if (bloodAlcoholContent>=BACThresholdLevels[currentThresholdIndex])
        {
            currentThresholdIndex++;
            SceneTransititoner.Instance.NextSceneTransition();
        }
    }

    public void EndDrinkAnim()
    {
        CameraController.Instance.SetToMainCam();
    }
    public void Puke()
    {
        CameraController.Instance.SetToCam(drinkingCam);
        drinkingCamAnimator.SetTrigger("puke");
    }
    public void PukeParticlePlay()
    {
        pukeParticle.Play();
    }
}
