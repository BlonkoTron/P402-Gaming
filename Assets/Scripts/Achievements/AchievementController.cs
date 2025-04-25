using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

public class AchievementController: MonoBehaviour
{
    public static AchievementController Instance;

    public UnityEvent<Achievement> OnAchievementUnlocked;

    public List<Achievement> Achievements;

    private Achievement achievementReadyToShow;

    public List<Achievement> unlockedAchievements = new List<Achievement>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    [HideInInspector] public void UnlockAchievement(string achievementName)
    {
        var newAchievement = GetAchievement(achievementName);
        if (newAchievement==null) { return; }
        if (!unlockedAchievements.Contains(newAchievement))
        {
            unlockedAchievements.Add(newAchievement);
            achievementReadyToShow = newAchievement;
        }
    }
    private Achievement GetAchievement(string achievementName)
    {
        for(int i=0;i<Achievements.Count;i++)
        {
            if (Achievements[i].name == achievementName)
            {
                return Achievements[i];
            }
        }
        return null;
    }
    public bool CheckIfNewAchievementUnlocked()
    {
        if (achievementReadyToShow!=null)
        {
            OnAchievementUnlocked.Invoke(achievementReadyToShow);
            achievementReadyToShow = null;
            return true;
        } else { return false; }

    }
    public void ResetAchievements()
    {
        unlockedAchievements.Clear();
    }
}
