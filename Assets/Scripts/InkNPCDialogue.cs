using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;
using Unity.Cinemachine;

public class InkNPCDialogue: InkDialogue
{
    public static event Action<Story> OnCreateStory;

    [SerializeField] private CinemachineCamera dialogueCam;
    [SerializeField] private GameObject dialogueCanvas;

    void Awake()
    {
        dialogueCanvas.SetActive(false);
    }
    public override void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        dialogueCanvas.SetActive(true);
        RefreshView();
        CameraController.Instance.SetToCam(dialogueCam);
    }
    protected override void EndStory()
    {
        dialogueCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerInteract.isInteracting = false;
        RemovePreviousChoices();
        CameraController.Instance.SetToMainCam();
    }
}
