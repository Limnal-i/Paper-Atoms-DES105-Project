using UnityEngine;

public class OtherCollision : MonoBehaviour
{
    // will need to destroy these first and then only after Instantiating the other object can this be deleted fully
    Rigidbody2D ridgid;
    CircleCollider2D polycoll;
    SpriteRenderer spriterend;

    // Object prefabs to spawn (use serializedField as this only need editing in prefab via the editor and will never be changed otherwise)
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject AtomObject;

    // Start is called before the first frame update
    void Start()
    {
        ridgid = GetComponent<Rigidbody2D>();
        polycoll = GetComponent<CircleCollider2D>();
        spriterend = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAtom"))
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
        else if (collision.gameObject.CompareTag("Atom"))
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