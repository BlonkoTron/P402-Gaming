using UnityEngine;

public class Neon_flicker : MonoBehaviour
{
    [SerializeField] private Material NeoonPurlpe;

    public float targetTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NeoonPurlpe.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 1.0f)
        {
            NeoonPurlpe.color = Color.black;
        }

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        targetTime = 2.0f;
        NeoonPurlpe.color = Color.red;
    }
}
