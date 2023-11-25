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
        if (collision.gameObject.CompareTag("PlayerAtom"))
        Destroy(spriterend);
        Destroy(ridgid);
        Destroy(polycoll);

        Instantiate(playerObject, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Atom"))
            Destroy(spriterend);
        Destroy(ridgid);
        Destroy(polycoll);

        Instantiate(AtomObject, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }
}