
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    SceneChanger changer;

    ObjectChildCounter counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<ObjectChildCounter>();
        changer = GetComponent<SceneChanger>();
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
