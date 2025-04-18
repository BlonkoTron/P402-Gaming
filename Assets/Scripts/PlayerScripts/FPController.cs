using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 3f;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform armatureTransform;

    [SerializeField] private float drunkThreshold = 1.2f;

    private CharacterController cc;
    public Vector3 movement;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 DrunkDirection;
    private float ySpeed = 15;



    private float lerpT = 0;
    private float lerpMinimum = -1f;
    private float lerpMaximum = 1f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!PlayerInteract.isInteracting)
        {
            Move();
        }   
        
        transform.rotation = new Quaternion(transform.rotation.x, cameraTransform.rotation.y,transform.rotation.z,transform.rotation.w);

    }

    private void Move()
    {
        if (DrinkingController.bloodAlcoholContent >= drunkThreshold)
        {
            if (movement != Vector3.zero)
            {
                Vector3 DrunkMovement = new Vector3(Mathf.Lerp(lerpMinimum, lerpMaximum, lerpT), 0, 0);

                lerpT += 0.5f * Time.fixedDeltaTime;

                if (lerpT > 1.0f)
                {
                    float temp = lerpMaximum;
                    lerpMaximum = lerpMinimum;
                    lerpMinimum = temp;
                    lerpT = 0.0f;
                }

                //DrunkDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * DrunkMovement.normalized;

            }
            else
            {
                DrunkDirection = Vector3.zero;
            }

           
        }



        // here we calculate the direction our character should be moving based on the camera position
        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement.normalized+DrunkDirection.normalized;


        //mash it together with the speed to get the disired movement :)
        velocity = direction * moveSpeed;

        //Gravity moment
        velocity.y = -ySpeed * Time.fixedDeltaTime;

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
