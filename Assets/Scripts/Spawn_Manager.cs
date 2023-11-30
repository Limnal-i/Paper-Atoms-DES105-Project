using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] GameObject otherObjects;
    [SerializeField] GameObject npcAtoms;

    GameObject[] SearchAmount;

    float maxRange_X = 934.76f;
    float maxRange_Y = 497.1844f;

    float minRange_X = -896.34f;
    float minRange_Y = -496.27f;

    Vector3 randPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            objectSpawner(otherObjects);
        }

    }

    // Update is called once per frame
    void Update()
    {
        SearchAmount = GameObject.FindGameObjectsWithTag("Object");
        if (SearchAmount.Length < 5000)
        {
            for (int i = 0; i < 5000; i++)
            {
                objectSpawner(otherObjects);
            }
        }
    }

    float rand_numberPost(float min, float max)
    {
        float valueToReturn = Random.Range(min, max);

        return valueToReturn;
    }

    void objectSpawner(GameObject toSpawnin)
    {
        randPosition.x = rand_numberPost(minRange_X, maxRange_X);
        randPosition.y = rand_numberPost(minRange_Y, maxRange_Y);
        Instantiate(toSpawnin, randPosition, transform.rotation);
    }
}
