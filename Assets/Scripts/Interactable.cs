using UnityEngine;

public class Interactable : MonoBehaviour
{
    private InkDialogue inkDia;

    private void Awake()
    {
        inkDia = GetComponent<InkDialogue>();
    }

    public void Interacted()
    {
        Debug.Log(gameObject.name + " has been hit");

        if (inkDia != null)
        {
            inkDia.StartStory();
            PlayerInteract.isInteracting = true;
            Cursor.lockState = CursorLockMode.Confined;
        }


    }
}
