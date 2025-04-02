using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Cinemachine;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkDialogue : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;


	[SerializeField]
	protected TextAsset inkJSONAsset = null;
	public Story story;
	[SerializeField]
	protected TMP_Text dialogueTextField;
	[SerializeField]
	protected GameObject buttonPrefab = null;
	[SerializeField]
	protected GameObject buttonParent = null;
	[SerializeField]
	[Range(0.001f, 0.5f)] private float textSpeed=0.05f;


	// Creates a new Story object with the compiled story which we can then play
	public virtual void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		story.BindExternalFunction("Drink", (float amount) => {
			DrinkingController.Instance.Drink(amount);
		});
		RefreshView();
	}

	// This is the main function called every time the story changes. 
	protected void RefreshView()
	{
		// Remove previous choice buttons
		RemovePreviousChoices();
		StopAllCoroutines();

		// Read all the content until we can't continue any more
		while (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen
			StartCoroutine(WriteText(dialogueTextField, text));

		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				GameObject button = CreateChoiceView(choice.text.Trim());
				// Tell the button what to do when we press it
				button.GetComponent<Button>().onClick.AddListener(delegate {
					OnClickChoiceButton(choice);
				});  
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			EndStory();
		}
	}
	GameObject CreateChoiceView(string text)
	{
		// Creates the button from a prefab
		GameObject choice = Instantiate(buttonPrefab) as GameObject;
		choice.transform.SetParent(buttonParent.transform, false);

		// Gets the text from the button prefab
		TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
		choiceText.text = text;

		return choice;
	} protected virtual void EndStory()
    {

	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}
	protected void RemovePreviousChoices()
    {
		int childCount = buttonParent.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			Destroy(buttonParent.transform.GetChild(i).gameObject);
		}
	}
	protected IEnumerator WriteText(TMP_Text textField, string textToWrite)
	{
		int textLength = textToWrite.Length; // get length of chosen text
		string myText = textToWrite.Insert(0, "<alpha=#00>"); // set text invisible by inserting <alpha> attribute into start of the text
		int i = 0;
		// insert the <alpha> attribute to a new place each time, revealing a new character of the text, until everything is visible.
		while (i <= textLength)
		{
			myText = textToWrite.Insert(i, "<alpha=#00>");
			textField.text = myText;
			yield return new WaitForSeconds(textSpeed); // delay
			i++;
		}
		//writeTextDone = true;
	}
}
