using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;
using Unity.Cinemachine;

public class InkNPCDialogue: InkDialogue
{
    [SerializeField] private GameObject dialogueCanvas;
    private float playerActiveDelay=1;

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
        StartCoroutine(SetPlayerActiveDelay());
        RemovePreviousChoices();
        CameraController.Instance.SetToMainCam();
        base.EndStory();
    }
    private IEnumerator SetPlayerActiveDelay()
    {
        yield return new WaitForSeconds(playerActiveDelay);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerInteract.isInteracting = false;
    }
}
