using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom_Movement : MonoBehaviour
{


    Vector3 AtomMovement;

    Rigidbody2D Atom_Rigidbody;

    float AtomMovementSpeed = 10;



    // Start is called before the first frame update
    void Start()
    {
        AtomMovement = new Vector3();
        Atom_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
