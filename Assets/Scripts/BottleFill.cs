using UnityEngine;

public class BottleFill : MonoBehaviour
{
    [SerializeField] private float minValue = 0.5f;
    [SerializeField] private float maxValue = 0.65f;

    [SerializeField] private Material bottleFillMat;
    void Start()
    {
        DrinkingController.Instance.OnDrink += UpdateBottleFill;
        UpdateBottleFill();
    }
    private void OnDestroy()
    {
        DrinkingController.Instance.OnDrink -= UpdateBottleFill;
    }
    private void UpdateBottleFill()
    {
        // DrinkingController.Instance.bloodAlcoholContent;
        var range = maxValue - minValue;
        var newFill=minValue+range* DrinkingController.Instance.bloodAlcoholContent;
        // bottleFillMat - something 
        bottleFillMat.SetFloat("_Fill",newFill);
    }


}
