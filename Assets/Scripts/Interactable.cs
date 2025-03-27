using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interacted()
    {
        Debug.Log(gameObject.name + " has been hit");
    }
}
