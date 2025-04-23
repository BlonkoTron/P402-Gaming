using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class PlayerAnimationController : MonoBehaviour
{

    private FPController FP;
    private Animator animator;

    private float movementValue;
    private float lerpT;

    void Start()
    {
        animator = GetComponent<Animator>();
        FP = GetComponent<FPController>();
        DrinkingController.Instance.OnDrink += Drink;
    }
    private void OnDisable()
    {
        DrinkingController.Instance.OnDrink -= Drink;

    }
    // Update is called once per frame
    void Update()
    {
        if (FP.movement != Vector3.zero)
        {
          
            movementValue = Mathf.Lerp(0, FP.movement.magnitude, lerpT);

            lerpT += 1.5f * Time.deltaTime;
        }
        else 
        {
            if (movementValue > 0)
            {
                movementValue -= 1.5f * Time.deltaTime;
                
            }

            if (lerpT > 0)
            {
                lerpT -= 1.5f * Time.deltaTime;
            }
        }


        animator.SetFloat("movement", movementValue);
    }
    private void Drink()
    {
        animator.SetTrigger("Drink");
    }
}
