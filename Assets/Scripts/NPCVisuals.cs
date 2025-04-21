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
        inkDialogue.OnStartStory.AddListener(StartConversation);
        inkDialogue.OnEndStory.AddListener(EndConversation);

    }
    private void OnDisable()
    {
        inkDialogue.OnStartStory.RemoveListener(StartConversation);
        inkDialogue.OnEndStory.RemoveListener(EndConversation);
    }
    private void StartConversation()
    {
        npcAnimator.SetBool("Talking",true);
    }
    private void EndConversation()
    {
        npcAnimator.SetBool("Talking", false);
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
