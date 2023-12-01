using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Scrawl : MonoBehaviour
{
    // Keeps player within bounds without stopping them
    // Adapted from https://medium.com/@amber.codes/unity-wrapping-player-movement-e3c3ddc151cf

    CapsuleCollider2D ObjectColl;

    float currentPlayerX = 0;
    float currentPlayerY = 0;


    // Start is called before the first frame update
    void Start()
    {
        ObjectColl = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        currentPlayerX = transform.position.x;
        currentPlayerY = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bounds Top")
        {
            transform.position = new Vector3(currentPlayerX, -80, 0);
        }
        if (collision.gameObject.name == "Bounds Bottom")
        {
            transform.position = new Vector3(currentPlayerX, 80, 0);
        }
        if (collision.gameObject.name == "Bounds Left")
        {
            transform.position = new Vector3(130, currentPlayerY, 0);
        }
        if (collision.gameObject.name == "Bounds Right")
        {
            transform.position = new Vector3(-130, currentPlayerY, 0);
        }
    }
}
