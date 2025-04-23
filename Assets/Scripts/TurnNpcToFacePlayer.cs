using System.Collections;
using UnityEngine;

public class TurnNpcToFacePlayer : MonoBehaviour
{
    [SerializeField] private float rotationSpd = 50f;
    [SerializeField] private Transform target;

    private Quaternion targetRotation;
    private Quaternion originalRotation;
    private Vector3 direction;

    private InkDialogue ink;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        originalRotation = transform.rotation;
        direction = target.position - transform.position;

        ink = GetComponent<InkDialogue>();

        if ( ink != null)
        {
            ink.OnEndStory.AddListener(FaceReset);
        }
        

    }

    private void FixedUpdate()
    {
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpd * Time.fixedDeltaTime);
            }
     
    }

    public void FacePlayer()
    {
        direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z), transform.up);
        targetRotation = lookRotation;
    }

    public void FaceReset()
    {
        targetRotation = originalRotation;
    }
}
