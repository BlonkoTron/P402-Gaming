using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private Transform cameraTransform;

    private CharacterController cc;
    private Vector3 movement;
    private Vector3 velocity;
    private float ySpeed;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        // here we calculate the direction our character should be moving based on the camera position
        Vector3 direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement.normalized;

        //mash it together with the speed to get the disired movement :)
        velocity = direction * moveSpeed;

        //Gravity moment
        ySpeed = Physics.gravity.y * Time.fixedDeltaTime;

        velocity.y = ySpeed;

        //Moving
        cc.Move(velocity * Time.fixedDeltaTime);
    }

    #region input
    private void OnLook(InputValue input)
    {
        //lookPos = input.Get<Vector2>();
    }

    private void OnMove(InputValue input)
    {
        movement = input.Get<Vector3>();
    }
    #endregion
}
