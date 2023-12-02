using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectChildCounter : MonoBehaviour
{
    // Start is called before the first frame update

    int ChildCounter;

    private void FixedUpdate()
    {
        ChildCounter = gameObject.transform.childCount;
        ChildCounter = ChildCounter--;
        Debug.Log("You have " +  ChildCounter + " amount collected.");
    }

    public  int getChildCount()
    {
        ChildCounter = ChildCounter--;
        return ChildCounter;
    }
}
