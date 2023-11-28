using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectCreator : MonoBehaviour
{

    PolygonCollider2D polycoll;

    // Start is called before the first frame update
    void Start()
    {
        polycoll = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {

        }
    }

}
