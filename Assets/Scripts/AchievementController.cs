using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class AchievementController: MonoBehaviour
{
    public static AchievementController Instance;

    public UnityEvent<string> OnAchievementUnlocked;

    public readonly List<string> unlockedAchievements = new List<string>();

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
    public void UnlockAchievement(string achText)
    {
        if (!unlockedAchievements.Contains(achText))
        {
            unlockedAchievements.Add(achText);
        }
    }
}
