using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneTransititoner : MonoBehaviour
{
    public static SceneTransititoner Instance;

    [SerializeField] private float fadeOutTime = 2;
    [SerializeField] private float transitionTimer = 2;
    [SerializeField] private Image transitionPanel;
    [SerializeField] private AnimationCurve fadeOutCurve;
    [SerializeField] private AnimationCurve fadeInCurve;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void NextSceneTransition()
    {
        StartCoroutine(SceneTransition(transitionTimer));
    }
    private IEnumerator SceneTransition(float timer)
    {
        float journey = 0f;
        while (journey <= timer)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / timer);
            // fade in panel over time
            var fade = fadeOutCurve.Evaluate(percent);
            transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, fade);
            yield return null;
        }
        if (journey > timer)
        {
            var nextScene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
            if (nextScene != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
        }
    }
    private IEnumerator FadeTimer(float timer)
    {
        float journey = 0f;
        while (journey <= timer)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / timer);
            // fade in panel over time
            var fade = fadeInCurve.Evaluate(percent);
            transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, fade);
            yield return null;
        }
    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode mode) 
    {
        StartCoroutine(FadeTimer(fadeOutTime));
    }
}
