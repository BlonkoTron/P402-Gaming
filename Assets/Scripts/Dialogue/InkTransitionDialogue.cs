using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InkTransitionDialogue: InkDialogue
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        StartStory();
    }
    protected override void EndStory()
    {
        RemovePreviousChoices();
        // transition to new scene
        SceneTransititoner.Instance.NextSceneTransition();
    }
}
