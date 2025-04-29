using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class DrinkingController : MonoBehaviour
{
    public static DrinkingController Instance;

    public UnityAction OnDrink;

    [HideInInspector] public CinemachineCamera drinkingCam;
    public static float bloodAlcoholContent=0;
    public static float[] BACThresholdLevels = new float[] { 0.3f, 0.7f, 1f };
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
        DrunkVisionController.Instance.UpdateDrunkVision(bloodAlcoholContent);
    }
    
    public void Drink(float amount)
    {
        bloodAlcoholContent += amount;
        OnDrink.Invoke();
        DrunkVisionController.Instance.UpdateDrunkVision(bloodAlcoholContent);
        Drunkeffect.Instance.UpdateDrunkAudio(bloodAlcoholContent);
    }
    private void DisableInputs()
    {
        var inputhandler = GameObject.FindGameObjectWithTag("InputHandler");
        if (inputhandler != null)
        {
            inputhandler.GetComponent<PlayerInput>().enabled = false;
        }
        this.gameObject.GetComponent<PlayerInput>().enabled = false;
    }

    public void EndDrinkAnim()
    {
        CameraController.Instance.SetToMainCam();
    }
    public void CheckBACForTransition()
    {
        if (bloodAlcoholContent >= BACThresholdLevels[currentThresholdIndex])
        {
            currentThresholdIndex++;
            DisableInputs();
            SceneTransititoner.Instance.NextSceneTransition();
        }
    }
}
