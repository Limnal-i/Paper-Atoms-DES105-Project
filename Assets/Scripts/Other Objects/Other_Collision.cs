using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other_Collision : MonoBehaviour
{
    Rigidbody2D ridgid;
    PolygonCollider2D polycoll;
    SpriteRenderer spriterend;

    public GameObject playerObject;
    public GameObject AtomObject;

    // Start is called before the first frame update
    void Start()
    {
        ridgid = GetComponent<Rigidbody2D>();
        polycoll = GetComponent<PolygonCollider2D>();
        spriterend = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAtom") || collision.gameObject.CompareTag("PlayerObject"))
        {
            //turn object invisible and destroy collision detection
            Destroy(spriterend);
            Destroy(ridgid);
            Destroy(polycoll);
            //create new object at current position and rotation
            Instantiate(playerObject, transform.position, transform.rotation, collision.transform);
            //destroy self
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Atom") || collision.gameObject.CompareTag("AtomObject"))
        {
            //turn object invisible and destroy collision detection
            Destroy(spriterend);
            Destroy(ridgid);
            Destroy(polycoll);
            //create new object at current position and rotation
            Instantiate(AtomObject, transform.position, transform.rotation, collision.transform);
            //destroy self
            Destroy(gameObject);
        }

    }
}