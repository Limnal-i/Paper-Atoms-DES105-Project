using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneChange : MonoBehaviour
{
    SceneChanger changer;

    ObjectChildCounter counter;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<ObjectChildCounter>();
        changer = GetComponent<SceneChanger>();

        // Scene Checking code adapted from https://discussions.unity.com/t/how-to-check-which-scene-is-loaded-and-write-if-code-for-it/163399/2
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        if (sceneName == "EndlessGameScene")
        {
            Destroy(gameObject.GetComponent<PlayerSceneChange>());
        }
    }

    private void Update()
    {
        // when player gets amount of Objects, change scene
        if (counter.getChildCount() > 1500)
        {
            changer.toGameOver();
        }

    }
}
