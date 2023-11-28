using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerObjectCreator : MonoBehaviour
{

    PolygonCollider2D polycoll;

    public GameObject playerObject;

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
            //create new object at the position and rotation of the collided object, 
            //Instantiate(playerObject, , false);
        }
    }

}
