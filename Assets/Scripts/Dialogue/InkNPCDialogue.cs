using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;
using Unity.Cinemachine;

public class InkNPCDialogue: InkDialogue
{
    [SerializeField] private GameObject dialogueCanvas;

    void Awake()
    {
        dialogueCanvas.SetActive(false);
    }
    public override void StartStory()
    {
        base.StartStory();
        dialogueCanvas.SetActive(true);
        CameraController.Instance.SetToNpcCam(transform);
    }
    protected override void EndStory()
    {
        dialogueCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerInteract.isInteracting = false;
        RemovePreviousChoices();
        CameraController.Instance.SetToMainCam();
        base.EndStory();
    }
}
