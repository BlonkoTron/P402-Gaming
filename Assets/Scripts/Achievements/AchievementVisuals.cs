using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class AchievementVisuals : MonoBehaviour
{
    [SerializeField] private TMP_Text _achievementText;
    [SerializeField] private Image _achievementImage;
    [SerializeField] private GameObject _achievementBox;
    private Animator _achievementAnimator;

    private float _achievementAnimationTime=4f;


    void Start()
    {
        AchievementController.Instance.OnAchievementUnlocked.AddListener(ShowAchievementUnlocked);
        _achievementAnimator = _achievementBox.GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        AchievementController.Instance.OnAchievementUnlocked.RemoveListener(ShowAchievementUnlocked);
    }
    private void ShowAchievementUnlocked(Achievement achievement)
    {
        _achievementText.text = achievement.text;
        _achievementImage.sprite = achievement.sprite;
        StartCoroutine(AchievementAnimation());
    }
    private IEnumerator AchievementAnimation()
    {
        _achievementAnimator.SetBool("active", true);
        yield return new WaitForSeconds(_achievementAnimationTime);
        _achievementAnimator.SetBool("active", false);
    }
}
