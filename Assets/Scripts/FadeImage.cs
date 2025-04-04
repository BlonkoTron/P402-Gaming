using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private float fadeTime= 2;
    [SerializeField] private AnimationCurve fadeCurve;
    private Image myImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myImage = GetComponent<Image>();
        StartCoroutine(FadeTimer(fadeTime));
    }

    private IEnumerator FadeTimer(float timer)
    {
        float journey = 0f;
        while (journey <= timer)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / timer);
            // fade in panel over time
            var fade = fadeCurve.Evaluate(percent);
            myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, fade);
            yield return null;
        }
    }
}
