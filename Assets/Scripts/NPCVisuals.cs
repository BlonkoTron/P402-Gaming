using UnityEngine;

public class NPCVisuals : MonoBehaviour
{
    protected Animator npcAnimator;
    protected InkDialogue inkDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        inkDialogue = GetComponent<InkDialogue>();
        npcAnimator = GetComponent<Animator>();
        inkDialogue.OnStartStory.AddListener(StartConversation);
        inkDialogue.OnEndStory.AddListener(EndConversation);

    }
    protected void OnDisable()
    {
        inkDialogue.OnStartStory.RemoveListener(StartConversation);
        inkDialogue.OnEndStory.RemoveListener(EndConversation);
    }
    protected virtual void StartConversation()
    {
        npcAnimator.SetBool("Talking",true);
    }
    protected virtual void EndConversation()
    {
        npcAnimator.SetBool("Talking", false);
    }
}
