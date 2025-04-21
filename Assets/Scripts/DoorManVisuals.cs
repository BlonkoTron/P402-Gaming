using UnityEngine;

public class DoorManVisuals : NPCVisuals
{
    protected override void  EndConversation()
    {
        npcAnimator.SetTrigger("move");
        npcAnimator.SetBool("Talking", false);
    }
}
