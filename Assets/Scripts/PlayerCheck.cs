using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    SceneChanger changer;

    ObjectChildCounter counter;

    Camera LevelCam;

    Rigidbody2D Rigidbody;

    CapsuleCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<ObjectChildCounter>();
        changer = GetComponent<SceneChanger>();
    }

    private void Update()
    {
        if (counter.getChildCount() > 5)
        {
            changer.toGameOver();
        }
    }
}
