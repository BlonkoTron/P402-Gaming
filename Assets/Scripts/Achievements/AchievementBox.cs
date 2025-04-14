using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementBox : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;
    public void Setup(Achievement ach)
    {
        image.sprite = ach.sprite;
        text.text = ach.text;
    }
}
