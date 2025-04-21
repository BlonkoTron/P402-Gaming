using UnityEngine;

public class NPCVisuals : MonoBehaviour
{
    private Animator npcAnimator;
    private InkDialogue inkDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inkDialogue = GetComponent<InkDialogue>();
        npcAnimator = GetComponent<Animator>();
        inkDialogue.OnStartWritingText += StartTalking;
        inkDialogue.OnEndWritingText += StopTalking;
        inkDialogue.OnStartStory.AddListener(StartConversation);
        inkDialogue.OnEndStory.AddListener(EndConversation);

    }
    private void OnDestroy()
    {
        inkDialogue.OnStartWritingText -= StartTalking;
        inkDialogue.OnEndWritingText -= StopTalking;
        inkDialogue.OnStartStory.RemoveListener(StartConversation);
        inkDialogue.OnEndStory.RemoveListener(EndConversation);
    }
    private void StartConversation()
    {

    }
    private void EndConversation()
    {
        //npcAnimator.SetTrigger("idle");
    }

    private void StartTalking()
    {
        //npcAnimator.SetTrigger("talk");
    }
    private void StopTalking()
    {
        //npcAnimator.SetTrigger("idle");
    }
}
