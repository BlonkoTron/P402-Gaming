using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InkTransitionDialogue: InkDialogue
{
    [SerializeField] private float transitionTimer=2;
    [SerializeField] private Image transitionPanel;
    [SerializeField] private AnimationCurve fadeCurve;
    private void Awake()
    {
        StartStory();
    }
    protected override void EndStory()
    {
        RemovePreviousChoices();
        // transition to new scene
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
            var fade = fadeCurve.Evaluate(percent);
            transitionPanel.color =new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, fade);
            yield return null;
        }
        if (journey > timer)
        {
            var nextScene = SceneManager.GetSceneByBuildIndex( SceneManager.GetActiveScene().buildIndex + 1);
            if (nextScene!=null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
        }
    }
}
