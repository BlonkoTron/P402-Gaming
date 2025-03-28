public class InkIntroDialogue: InkDialogue
{
    private void Awake()
    {
        StartStory();
    }
    protected override void EndStory()
    {
        RemovePreviousChoices();

        // transsition to new scene
    }
}
