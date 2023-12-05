using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    SceneChanger changer;

    ObjectChildCounter counter;

    MasterPlayer_Input mastInput;

    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<ObjectChildCounter>();
        changer = GetComponent<SceneChanger>();
    }

    private void Update()
    {
        if (counter.getChildCount() > 1500)
        {
            changer.toGameOver();
        }
    }
}
