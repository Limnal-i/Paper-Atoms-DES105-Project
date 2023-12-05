
using UnityEngine;

public class ObjectChildCounter : MonoBehaviour
{
    // Start is called before the first frame update

    int ChildCounter;

    private void FixedUpdate()
    {
        ChildCounter = gameObject.transform.childCount;
        ChildCounter = ChildCounter--;

        // as Camera is a child, reduce count by one to only check child Objects

        Debug.Log("You have " +  ChildCounter + " objects collected!");
    }

    public  int getChildCount()
    {
        ChildCounter = ChildCounter--;
        return ChildCounter;
    }
}
