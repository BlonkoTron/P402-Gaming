using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenAchievements : MonoBehaviour
{
    private AchievementController achievementController;

    [SerializeField] private GameObject achievementBoxPrefab;
    [SerializeField] private Transform achievementContainer;
    [SerializeField] private TMP_Text achivementCountText;

    void Start()
    {
        achievementController = AchievementController.Instance;
        if (achievementController==null) { return; }

        SetAchievementCounter();
        if (achievementController.unlockedAchievements.Count>0)
        {
            SpawnAchievmentBoxes();
        }
    }
    private void SpawnAchievmentBoxes()
    {
        for (int i = 0; i < achievementController.unlockedAchievements.Count; i++)
        {
            GameObject newBox = Instantiate(achievementBoxPrefab, achievementContainer);
            newBox.GetComponent<AchievementBox>().Setup(achievementController.unlockedAchievements[i]);
        }
    }
    private void SetAchievementCounter()
    {
        achivementCountText.text = "Du fandt "+ achievementController.unlockedAchievements.Count+"/"+achievementController.Achievements.Count+ " tegn på alkoholproblemer";
    }
}
