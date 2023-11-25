using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Atom_ChildMovement : MonoBehaviour
{
    Rigidbody2D Atom_Rigidbody;
    //Atom_Movement targetAtomMovement;

    GameObject targetAtomMovement;

    Vector3 ChildAtomMovement;

    // Start is called before the first frame update
    void Start()
    {
        Atom_Rigidbody = GetComponent<Rigidbody2D>();

        targetAtomMovement = getNearestAtom();
    }

    //Fixed Update is used for physics as framerate and physics are updated at different intervals 
    private void FixedUpdate()
    {
        // Set Object's velocity to match nearest Atom
        ChildAtomMovement = new Vector3();
        
        ChildAtomMovement = targetAtomMovement.GetComponent<Rigidbody2D>().velocity;

        Atom_Rigidbody.velocity = ChildAtomMovement;
    }

    public GameObject getNearestAtom()
    {
        GameObject[] AllAtoms;
        AllAtoms = GameObject.FindGameObjectsWithTag("Atom");
        GameObject closest = null;

        float distance = Mathf.Infinity;

        Vector3 atomChildPosition = transform.position;

        foreach (GameObject checkAtom in AllAtoms)
        {
            Vector3 difference = checkAtom.transform.position - atomChildPosition;
            float AtomDistance = difference.sqrMagnitude;
            if (AtomDistance < distance)
            {
                closest = checkAtom;
                distance = AtomDistance;
            }
        }
        Debug.Log(closest.name);
        return closest;
    }


    /*oh boy
     * https://forum.unity.com/threads/how-to-find-the-nearest-object.360952/
     * 
     * public GameObject GetClosestObject()
    {
      float closest = 1000; //add your max range here
      GameObject closestObject = null;
      for (int i = 0; i < MyListOfObjects.Count; i++)  //list of gameObjects to search through
      {
        float dist = Vector3.Distance(MyListOfObjects[ i ].transform.position, player.transform.position);
        if (dist < closest)
        {
          closest = dist;
          closestObject = MyListOfObjects[ i ];
        }
      }
    return closestObject;
    }
        from documentation

            public GameObject FindClosestEnemy()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }


    */
}