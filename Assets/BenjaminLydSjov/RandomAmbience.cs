using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using FMOD;
public class RandomAmbience : MonoBehaviour
{
    private EventInstance soundInstance;
    private EventInstance soundInstance2;
    [SerializeField] private EventReference Sound1;
    [SerializeField] private EventReference Sound2;

    private int RandomINT1 = 0;
    private int RandomINT2 = 0;
    private int RandomINT3 = 0;
    private int RandomINT4 = 0;
    private int RandomINT5 = 0;

    // Update is called once per frame
    void Update()
    {
        RandomINT1= Random.Range(0, 200);
        print(RandomINT1);
        if (RandomINT1 == 69)
        {
            soundInstance = Audiomanager.instance.PlaySound(Sound1, transform.position);
        }
    }
}
