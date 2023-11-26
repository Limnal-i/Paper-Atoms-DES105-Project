using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // This entire thing is based on the Unity Doucumentation code https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    // Did start out with https://forum.unity.com/threads/how-to-find-the-nearest-object.360952/ which... didn't work but got me on the right track
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
