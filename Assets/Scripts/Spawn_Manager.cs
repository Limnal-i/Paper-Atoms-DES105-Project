using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class Spawn_Manager : MonoBehaviour
{
    // Object prefabs to spawn (use serializedField as this only need editing in prefab via the editor and will never be changed otherwise)
    [SerializeField] GameObject otherObjects;
    [SerializeField] GameObject npcAtoms;

    // for use in counting amount of objects
    GameObject[] SearchAmount;
    
    // Defining the area where game objects can spawn in
    float maxRange_X = 159f;
    float maxRange_Y = 89f;

    float minRange_X = -159f;
    float minRange_Y = -89f;

    // Store the random position
    Vector3 randPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // create 500 objects and spawn 10 npc atoms
        for (int i = 0; i != 1000; i++)
        {
            objectSpawner(otherObjects);
        }
        for (int i = 0; i < 50; i++)
        {
            objectSpawner(npcAtoms);
        }
    }

    // Constantly check amount of objects and spawn in more if needed
    private void FixedUpdate()
    {
        SearchAmount = GameObject.FindGameObjectsWithTag("Object");
        if (SearchAmount.Length < 950)
        {
            for (int i = 0; i < 50; i++)
            {
                objectSpawner(otherObjects);
            }
        }
    }

    // gets a random position within passed in bounds
    float rand_numberPostition(float min, float max)
    {
        float valueToReturn = Random.Range(min, max);

        return valueToReturn;
    }

    // generic game object spawner
    void objectSpawner(GameObject toSpawnIn)
    {
        randPosition.x = rand_numberPostition(minRange_X, maxRange_X);
        randPosition.y = rand_numberPostition(minRange_Y, maxRange_Y);
        Instantiate(toSpawnIn, randPosition, transform.rotation);
    }
}
