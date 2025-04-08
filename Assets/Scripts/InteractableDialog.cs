using UnityEngine;

public class InteractableDialog : Interactable
{
    private InkDialogue inkDia;

    private void Awake()
    {
        inkDia = GetComponent<InkDialogue>();
    }

    public override void Interacted()
    {
        Debug.Log(gameObject.name + " has been hit");

        if (inkDia != null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            //transform.LookAt(player.transform, Vector3.up);
            inkDia.StartStory();
            PlayerInteract.isInteracting = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
