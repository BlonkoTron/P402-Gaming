using UnityEngine;
using UnityEngine.Events;

public class DrinkingController : MonoBehaviour
{
    public static DrinkingController Instance;

    public UnityAction OnDrink;

    public float bloodAlcoholContent=0;

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

    public void Drink(float amount)
    {
        bloodAlcoholContent += amount;
        Debug.Log("You drink");
        OnDrink.Invoke();
    }
}
