using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAtomChildMovement : MonoBehaviour
{
    Rigidbody2D Atom_Rigidbody;
    //Atom_Movement targetAtomMovement;

    GameObject targetAtomMovement;

    Vector3 ChildAtomMovement;

    // Start is called before the first frame update
    void Start()
    {
        Atom_Rigidbody = GetComponent<Rigidbody2D>();

        targetAtomMovement = GameObject.FindGameObjectWithTag("PlayerAtom"); /// returns closest Atom (nonplayer)
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        // Set Object's velocity to match nearest Atom
        ChildAtomMovement = new Vector3();

        ChildAtomMovement = targetAtomMovement.GetComponent<Rigidbody2D>().velocity;

        Atom_Rigidbody.velocity = ChildAtomMovement;
    }
}