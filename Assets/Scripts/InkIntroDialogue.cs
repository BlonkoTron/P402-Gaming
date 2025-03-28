using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine;
public class InkIntroDialogue: InkDialogue
{
    [SerializeField] private float transitionTimer=2;
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

    private IEnumerator SceneTransition(float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("OscarTest",LoadSceneMode.Single);
    }
}
