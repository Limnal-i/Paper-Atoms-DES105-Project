using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Used to change Scenes (requires other scripts to call functions)

    public void toGameOver()
    {
        Debug.Log("Scene switched to EndScene");
        SceneManager.LoadScene("EndScene");
    }

    public void toMainGame()
    {
        Debug.Log("Scene switched to GameScene");
        SceneManager.LoadScene("GameScene");
    }

    public void toMainMenu()
    {
        Debug.Log("Scene switched to MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void toExitApp()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }
}
