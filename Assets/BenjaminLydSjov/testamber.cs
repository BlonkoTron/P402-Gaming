using UnityEngine;

public class testamber : MonoBehaviour
{
    public string soundplay;
    FMOD.Studio.EventInstance Sounding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sounding = FMODUnity.RuntimeManager.CreateInstance(soundplay);
        Sounding.start();
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Sounding,GetComponent<Transform>(),GetComponent<Rigidbody>());
    }
}
