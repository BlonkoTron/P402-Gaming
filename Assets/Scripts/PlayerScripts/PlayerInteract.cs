using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance;

    [SerializeField] private float throwPower;
    [SerializeField] private float raylength;

    [SerializeField] private GameObject holdPos;

    private int layerMask;

    private int firstPress;
    private bool grabbing;
    private GameObject grabbedObj;

    public static bool isInteracting = false;


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
                if (!isInteracting && !grabbing)
                {
                    interactable.Interacted();
                }

            }

        }
        if (grabbing)
        {
            if (firstPress > 0)
            {
                grabbedObj.transform.parent = null;
                grabbedObj.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObj.GetComponent<Throwable>().isGrabbed = false;
                grabbedObj.GetComponent<Collider>().enabled = true;
                grabbedObj.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * throwPower);
                grabbing = false;

            }
            else
            {
                firstPress++;
            }
        }

    }

    public void PickUp(GameObject grabObj)
    {
        if (!grabObj.GetComponent<Throwable>().isGrabbed)
        {
            grabObj.transform.parent = holdPos.transform;
            grabObj.GetComponent<Rigidbody>().isKinematic = true;
            grabObj.GetComponent<Throwable>().isGrabbed = true;
            grabObj.GetComponent<Collider>().enabled = false;
            grabbing = true;
            firstPress = 0;
            grabbedObj = grabObj;
        }
        
    }
}
