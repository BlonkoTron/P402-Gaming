using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
