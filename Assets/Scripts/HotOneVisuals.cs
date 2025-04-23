using UnityEngine;

public class HotOneVisuals : NPCVisuals
{
    protected override void EndConversation()
    {
        npcAnimator.SetTrigger("move");
        npcAnimator.SetBool("Talking", false);
    }
}
