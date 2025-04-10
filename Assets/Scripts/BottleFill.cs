using UnityEngine;

public class BottleFill : MonoBehaviour
{
    [SerializeField] private float minValue = 0.49f;
    [SerializeField] private float maxValue = 0.65f;

    private float startValue;

    [SerializeField] private Material bottleFillMat;
    void Start()
    {
        startValue = bottleFillMat.GetFloat("_Fill");
        DrinkingController.Instance.OnDrink += UpdateBottleFill;
        UpdateBottleFill();
    }
    private void OnDestroy()
    {
        DrinkingController.Instance.OnDrink -= UpdateBottleFill;
    }
    private void UpdateBottleFill()
    {
        var range = maxValue - minValue;
        var newFill=minValue+range* DrinkingController.Instance.bloodAlcoholContent;
        bottleFillMat.SetFloat("_Fill",newFill);
    }
    private void OnApplicationQuit()
    {
        bottleFillMat.SetFloat("_Fill", startValue);
    }


}
