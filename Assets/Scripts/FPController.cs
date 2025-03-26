using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;

    private Vector3 movement;
    private Vector3 lookPos;

    private void FixedUpdate()
    {

    }

    private void OnLook(InputValue input)
    {
        lookPos = input.Get<Vector3>();
    }

    private void OnMove(InputValue input)
    {
        movement = input.Get<Vector3>();
    }

}
