using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class DrinkingController : MonoBehaviour
{
    public static DrinkingController Instance;

    public UnityAction OnDrink;

    [HideInInspector] public CinemachineCamera drinkingCam;
    private Animator drinkingCamAnimator;
    public float bloodAlcoholContent=0;
    [SerializeField] private ParticleSystem pukeParticle;

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
