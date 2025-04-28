using Ink.Runtime;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using Ink.UnityIntegration;

[CustomEditor(typeof(InkDialogue))]
[InitializeOnLoad]
public class InkEditor : Editor
{
    static bool storyExpanded;

    static InkEditor()
    {
        InkDialogue.OnCreateStory += OnCreateStory;
    }

    static void OnCreateStory(Story story)
    {
        InkPlayerWindow window = InkPlayerWindow.GetWindow(false);
        if (window != null) InkPlayerWindow.Attach(story);
    }

    public override void OnInspectorGUI()
    {
        Repaint();
        base.OnInspectorGUI();
        var realTarget = target as InkDialogue;
        var story = realTarget.story;
        InkPlayerWindow.DrawStoryPropertyField(story, ref storyExpanded, new GUIContent("Story"));
    }
}
#endif

