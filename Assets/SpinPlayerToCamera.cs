using UnityEngine;

public class SpinPlayerToCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private float rotationSpd = 5.0f;


    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion toRoataion = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoataion, rotationSpd * Time.deltaTime);
    }
}
