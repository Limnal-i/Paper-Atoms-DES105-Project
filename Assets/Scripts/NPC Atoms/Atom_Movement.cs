using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom_Movement : MonoBehaviour
{
    Vector3 AtomMovement;
    Vector3 Target = Vector3.zero;

    Rigidbody2D Atom_Rigidbody;

    GameObject TargetObject;

    ObjectManager ObjectManager;

    float AtomMovementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        AtomMovement = new Vector3();

        Atom_Rigidbody = GetComponent<Rigidbody2D>();

        ObjectManager = GetComponent<ObjectManager>();
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        //TargetObject = getNearestObject();

        TargetObject = ObjectManager.getNearestObject("Object");

        Target = TargetObject.transform.position;

        Vector3 direction = (Target - transform.position).normalized;  //Gets direction of target

        Atom_Rigidbody.velocity = direction * AtomMovementSpeed;    //Sets Object velocity
    }
}
