using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
