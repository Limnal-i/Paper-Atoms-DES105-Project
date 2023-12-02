using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeIncreas : MonoBehaviour
{

    Camera PlayerCamera;
    ObjectChildCounter counter;

    float timeRemaining = 0.1f;

    int ChildCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = GetComponentInChildren<Camera>();

        counter = GetComponent<ObjectChildCounter>();
    }

    // Update is called once per frame
    //Timer stuff adapted from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    void Update()
    {
        ChildCount = counter.getChildCount();
        if (ChildCount == 2)
        {
            int i = 20;
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                PlayerCamera.orthographicSize = i;
                timeRemaining = 0.1f;
                i++;
            }
        }
        
    }
}
