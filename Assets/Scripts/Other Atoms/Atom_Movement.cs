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
        TargetObject = getNearestObject();

        Target = TargetObject.transform.position;

        Vector3 direction = (Target - transform.position).normalized;  //Gets direction of target

        Atom_Rigidbody.velocity = direction * AtomMovementSpeed;    //Sets Object velocity
    }

    // This entire thing is based on the Unity Doucumentation code https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    // Did start out with https://forum.unity.com/threads/how-to-find-the-nearest-object.360952/ which... didn't work but got me on the right track
    // Copied over from Atom_ChildMovement script with adjustment (not most efficent I know but it works)
    public GameObject getNearestObject()
    {
        GameObject[] AllAtoms; // for use in for loop

        AllAtoms = GameObject.FindGameObjectsWithTag("Object"); // Finds all tagged objects in scene

        GameObject closest = null; // set up for returning later

        float distance = Mathf.Infinity; // distance is forever (entire scene)

        Vector3 atomChildPosition = transform.position; // current position of Object this script is attatched to

        foreach (GameObject checkAtom in AllAtoms) // runs this on every GameObject to check
        {
            Vector3 difference = checkAtom.transform.position - atomChildPosition; // get distance between current object position and GameObject that is being checked

            float AtomDistance = difference.sqrMagnitude; // Gets the magnitude (cool maths that I don't have to do)

            if (AtomDistance < distance)
            {
                closest = checkAtom;
                distance = AtomDistance;

                // Checks if Object it is checking has a distance lesser than the current Max distance. Then it sets the closest object to it and updates the max distance to that.
            }
        }
        Debug.Log(closest.name); // prints out nearest Object with correct tag once all have been checked
        return closest; // Returns nearest Object with tag
    }

}
