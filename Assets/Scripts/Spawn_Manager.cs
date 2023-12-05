
using UnityEngine;


public class Spawn_Manager : MonoBehaviour
{
    // Object prefabs to spawn (use serializedField as this only need editing in prefab via the editor and will never be changed otherwise)
    [SerializeField] GameObject otherObjects;
    [SerializeField] GameObject npcAtoms;

    // for use in counting amount of objects
    GameObject[] SearchAmount;
    
    // Defining the area where game objects can spawn in
    float maxRange_X = 149f;
    float maxRange_Y = 89f;

    float minRange_X = -149f;
    float minRange_Y = -89f;

    // Store the random position
    Vector3 randPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // create 500 objects and spawn 10 npc atoms
        for (int i = 0; i != 500; i++)
        {
            objectSpawner(otherObjects);
        }
        for (int i = 0; i < 5; i++)
        {
            objectSpawner(npcAtoms);
        }
    }

    // Constantly check amount of objects every frame and spawn in more if needed
    void Update()
    {
        SearchAmount = GameObject.FindGameObjectsWithTag("Object");
        if (SearchAmount.Length < 450)
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

    // generic game object spawner (creates instance of object within range)
    void objectSpawner(GameObject toSpawnIn)
    {
        randPosition.x = rand_numberPostition(minRange_X, maxRange_X);
        randPosition.y = rand_numberPostition(minRange_Y, maxRange_Y);
        Instantiate(toSpawnIn, randPosition, transform.rotation);
    }
}
