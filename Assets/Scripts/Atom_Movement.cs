using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom_Movement : MonoBehaviour
{
    Vector3 AtomMovement;
    Vector3 Target = Vector3.zero;

    Rigidbody2D Atom_Rigidbody;

    GameObject TargetObject;

    float AtomMovementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        AtomMovement = new Vector3();

        Atom_Rigidbody = GetComponent<Rigidbody2D>();
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        //TargetObject = getNearestObject();

        TargetObject = getNearestObject("Object");

        Target = TargetObject.transform.position;

        Vector3 direction = (Target - transform.position).normalized;  //Gets direction of target

        Atom_Rigidbody.velocity = direction * AtomMovementSpeed;    //Sets Object velocity
    }

    public GameObject getNearestObject(string withTag)
    {
        GameObject[] AllObjects; // for use in for loop

        AllObjects = GameObject.FindGameObjectsWithTag(withTag); // Finds all tagged objects in scene

        GameObject closest = null; // set up for returning later

        float distance = Mathf.Infinity; // distance is forever (entire scene)

        Vector3 AttatchedObject = transform.position; // current position of Object this script is attatched to

        foreach (GameObject CheckObject in AllObjects) // runs this on every GameObject to check
        {
            Vector3 difference = CheckObject.transform.position - AttatchedObject; // get distance between current object position and GameObject that is being checked

            float objectDistance = difference.sqrMagnitude; // Gets the magnitude (cool maths that I don't have to do)

            if (objectDistance < distance)
            {
                closest = CheckObject;
                distance = objectDistance;

                // Checks if Object it is checking has a distance lesser than the current Max distance. Then it sets the closest object to it and updates the max distance to that.
            }
        }
        Debug.Log(closest.name); // prints out nearest Object with correct tag once all have been checked
        return closest; // Returns nearest Object with tag
    }
}
