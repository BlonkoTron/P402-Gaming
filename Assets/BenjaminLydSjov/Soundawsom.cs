using UnityEngine;

public class Soundawsom : MonoBehaviour
{
    public static Soundawsom Instance_sound;

    private void Awake()
    {

        //makes sure there is only one instance of the new gameobject
        if (Instance_sound != null)
        {
            Destroy(gameObject); //Den der
        }
        else
        {
            Instance_sound = this;
        }
    }

    public void playAudio(string soundName)
    {
        if (soundName != null)
        {

        }

        else
        {
            Debug.Log("No Soundname found");
        }
    }
}
