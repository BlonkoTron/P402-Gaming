using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float raylength;

    private int layerMask;

    public static bool isInteracting = false;


    private void Awake()
    {
        layerMask = 1 << 3;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raylength, layerMask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (!isInteracting)
                {
                    interactable.Interacted();
                }
            }

        }
    }

}
