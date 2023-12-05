using UnityEngine;
using UnityEngine.EventSystems;
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

    public void toControls()
    {
        Debug.Log("Scene switched to Controls");
        SceneManager.LoadScene("Controls");
    }

    public void toOptions()
    {
        Debug.Log("Scene switched to Options");
        SceneManager.LoadScene("Options");
    }
    public void ToEndlessMode()
    {
        Debug.Log("Scene switched to Endless Mode");
        SceneManager.LoadScene("EndlessGameScene");
    }

    public void toExitApp()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }
}
