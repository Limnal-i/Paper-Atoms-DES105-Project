using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayer_Input : MonoBehaviour
{
    //Allows for user to control Player Object from TopDown perspective

    Vector3 PlayerMovement;

    Rigidbody2D Player_Rigidbody;

    float PlayerMovementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = new Vector3();
        Player_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {


        // sets X and Y axis movement and allows WASD, Arrow Keys and Controller input to be used for movement)
        PlayerMovement.x = Input.GetAxisRaw("Horizontal");
        PlayerMovement.y = Input.GetAxisRaw("Vertical");

        // Add speed to movement
        PlayerMovement = PlayerMovement * PlayerMovementSpeed;

        // Directly assigns values to Attached Ridgidbody
        Player_Rigidbody.velocity = PlayerMovement;
    }

}
