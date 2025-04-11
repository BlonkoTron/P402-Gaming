using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Achievement", menuName = "Scriptable Objects/Achievement")]
public class Achievement : ScriptableObject
{
    public Sprite sprite;
    [Multiline]
    public string text;
}
