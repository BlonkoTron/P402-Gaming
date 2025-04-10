using UnityEngine;

public class Throwable : Interactable
{
    public bool isGrabbed;


    public override void Interacted()
    {
            PlayerInteract.Instance.PickUp(gameObject);
    }


}
