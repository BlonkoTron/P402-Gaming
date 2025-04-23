using UnityEngine;

public class InteractableDrink : Interactable
{
    public override void Interacted()
    {
        DrinkingController.Instance.Drink(0.1f);
        Destroy(this.gameObject);
    }
}
