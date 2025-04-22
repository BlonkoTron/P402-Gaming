using UnityEngine;

public class Neon_flicker : MonoBehaviour
{
    [SerializeField] private Material NeoonPurlpe;
    [SerializeField] private Material Neoonblue;
    [SerializeField] private Material Neoonyellow;
    [SerializeField] private Material NeoonOrange;

    public float targetTime = 2.0f;

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 1.0f)
        {
            NeoonPurlpe.color = new Color(1, 1, 1);
            Neoonblue.color = new Color(1, 1, 1);
            Neoonyellow.color = new Color(1, 1, 1);
            NeoonOrange.color = new Color(1, 1, 1);
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
        Neoonblue.color = Color.blue;
        Neoonyellow.color = Color.red;
        NeoonOrange.color = Color.red;
    }
}
