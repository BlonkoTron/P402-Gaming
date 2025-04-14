using System.Drawing;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private Transform cameraTransform;

    EventInstance musicInstance;
    [SerializeField] private EventReference Walking;
    [SerializeField] private float drunkThreshold;

    private CharacterController cc;
    public Vector3 movement;
    private Vector3 velocity;
    private float ySpeed;

    public Walking_Mixer MixerWalk;
    public float WalkingVolON = 1.0f;
    public float WalkingVolOFF = 0.0f;
    


    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        MixerWalk = GetComponent<Walking_Mixer>();
    }

    private void Start()
    {
        Audiomanager.instance.PlayOneShot(Walking, transform.position);
    }

    private void FixedUpdate()
    {
        if (!PlayerInteract.isInteracting)
        {
            Move();
        }
    }

    private void Move()
    {
        //Volume for walking turns on/off
        if (movement.x != 0 || movement.y != 0 || movement.z != 0)
        {
            MixerWalk.WalkingVol = WalkingVolON;
        }
        else
        {
            MixerWalk.WalkingVol = WalkingVolOFF;
        }
        

        // here we calculate the direction our character should be moving based on the camera position
        Vector3 direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement.normalized;

        if (DrinkingController.bloodAlcoholContent > drunkThreshold)
        {
            float drunkMovementFactor = Random.Range(-1, 2);

            Vector3 drunkDirection = transform.right.normalized * drunkMovementFactor;

            direction += drunkDirection;
        }


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
