using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    [SerializeField] private FPController controller;
    [SerializeField] private PlayerInteract playInt;

    private void OnMove(InputValue input)
    {
        controller.movement = input.Get<Vector3>();
    }

    private void OnInteract()
    {
        playInt.OnInteract();
    }


}
