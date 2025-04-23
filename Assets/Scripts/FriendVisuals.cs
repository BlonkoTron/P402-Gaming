using UnityEngine;

public class FriendVisuals : NPCVisuals
{
    protected override void EndConversation()
    {
        npcAnimator.SetTrigger("move");
        npcAnimator.SetBool("Talking", false);
    }
}

