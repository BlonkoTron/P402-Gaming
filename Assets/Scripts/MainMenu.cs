using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        AchievementController.Instance.ResetAchievements();
        SceneTransititoner.Instance.NextSceneTransition();
    }
    public void QuitGame()
    {
        Application.Quit();
    } 
}
