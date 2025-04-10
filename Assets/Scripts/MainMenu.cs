using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float transitionTimer = 1;
    [SerializeField] private Image transitionPanel;
    [SerializeField] private AnimationCurve fadeCurve;
    public void StartGame()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
        StartCoroutine(SceneTransition(transitionTimer));
    }
    public void QuitGame()
    {
        Application.Quit();
    } 
    private IEnumerator SceneTransition(float timer)
    {
        float journey = 0f;
        while (journey <= timer)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / timer);
            // fade in panel over time
            var fade = fadeCurve.Evaluate(percent);
            transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, fade);
            yield return null;
        }
        if (journey > timer)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
