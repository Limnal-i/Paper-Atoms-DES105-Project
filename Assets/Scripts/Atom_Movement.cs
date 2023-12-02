using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Atom_Movement : MonoBehaviour
{
    // Determins how atoms will move around scene

    // vector for storing target 
    Vector3 Target = Vector3.zero;

    // ridgidbody for velocity
    Rigidbody2D Atom_Rigidbody;

    // for storing nearest object
    GameObject TargetObject;

    // for checking player position
    GameObject AvoidThisPlayer;

    bool isMovingFromPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Atom_Rigidbody = GetComponent<Rigidbody2D>();
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        // Gets distance from nearest player object
        AvoidThisPlayer = getNearestObject("PlayerAtom");

        // IF ELSE WHILE HELL!
        MovementHell();
    }

    void MovementHell()
    {
        // if far enough, go to nearest object, else if player is too close, move away until distance is sufficent (do same with other atoms)
        if (Vector3.Distance(transform.position, AvoidThisPlayer.transform.position) > 10 && isMovingFromPlayer == false)
        {
            moveToOtherObject();
        }
        else if (Vector3.Distance(transform.position, AvoidThisPlayer.transform.position) < 10)
        {
            isMovingFromPlayer = true;
            moveAwayFromObject();
        }
        else if (Vector3.Distance(transform.position, AvoidThisPlayer.transform.position) > 50)
        {
            isMovingFromPlayer = false;
        }
    }

    // Finds nearest gameobject with passed in Tag
    public GameObject getNearestObject(string withTag)
    {
        // Adapted from Unity Document Example code (since it takes in a tag, can be reused if need be in future projects)

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
        return closest; // Returns nearest Object with tag
    }

    // Sets Atom to move towards nearest Object
    void moveToOtherObject()
    {
        // finds closest object with "object" tag
        TargetObject = getNearestObject("Object");

        // sets object as target position
        Target = TargetObject.transform.position;

        //Gets direction of target
        Vector3 direction = (Target - transform.position).normalized;

        //Sets Atom velocity in target direction
        Atom_Rigidbody.velocity = direction * 10;
    }

    // Sets Atom to move away from nearest specifed gameobject
    void moveAwayFromObject()
    {

        // Sets closest player affiliated object as target
        TargetObject = AvoidThisPlayer;

        // sets object as target position
        Target = TargetObject.transform.position;

        //Gets direction of target
        Vector3 direction = (Target - transform.position).normalized;

        //Sets Atom to move via force in opposite direction
        Atom_Rigidbody.AddForce(-direction * 1000);
    }
}
