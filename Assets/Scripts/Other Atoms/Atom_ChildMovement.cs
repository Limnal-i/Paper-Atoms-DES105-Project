using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Atom_ChildMovement : MonoBehaviour
{
    Rigidbody2D Atom_Rigidbody;

    GameObject targetAtomMovement;

    ObjectManager objectManager;

    Vector3 ChildAtomMovement;

    // Start is called before the first frame update
    void Start()
    {
        Atom_Rigidbody = GetComponent<Rigidbody2D>();

        objectManager = GetComponent<ObjectManager>();

        targetAtomMovement = objectManager.getNearestObject("Atom");
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        // Set Object's velocity to match nearest Atom
        ChildAtomMovement = new Vector3();

        ChildAtomMovement = targetAtomMovement.GetComponent<Rigidbody2D>().velocity;

        Atom_Rigidbody.velocity = ChildAtomMovement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAtom") || collision.gameObject.CompareTag("PlayerObject"))
        {

        }
    }
}