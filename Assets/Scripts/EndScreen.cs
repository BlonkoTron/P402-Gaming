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
        DrinkingController.bloodAlcoholContent = 0;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
