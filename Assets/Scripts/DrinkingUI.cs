using UnityEngine;
using UnityEngine.UI;

public class DrinkingUI : MonoBehaviour
{
    [SerializeField] private Image drinkingFillImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DrinkingController.Instance.OnDrink += UpdateDrinkUI;
        UpdateDrinkUI();
    }
    private void OnDestroy()
    {
        DrinkingController.Instance.OnDrink -= UpdateDrinkUI;

    }
    private void UpdateDrinkUI()
    {
        drinkingFillImage.fillAmount = DrinkingController.bloodAlcoholContent;
    }
}
