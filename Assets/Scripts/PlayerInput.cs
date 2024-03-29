using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Allows for user to control Player Object from TopDown perspective
    
    Vector3 PlayerMovement;

    Rigidbody2D Player_Rigidbody;

    float PlayerMovementSpeed = 10;


    // Allows player to call Pause Menu

    [SerializeField] GameObject pausemenu;

    // Start is called before the first frame update
    void Start()
    {
        // Start
        Time.timeScale = 1f;

        PlayerMovement = new Vector3();

        Player_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // sets X and Y axis movement and allows WASD, Arrow Keys and Controller input to be used for movement)
        PlayerMovement.x = Input.GetAxisRaw("Horizontal");
        PlayerMovement.y = Input.GetAxisRaw("Vertical");

        // Add speed to movement
        PlayerMovement = PlayerMovement * PlayerMovementSpeed;

        // Directly assigns values to Attached Ridgidbody
        Player_Rigidbody.velocity = PlayerMovement;

        // if ESC is pressed, pause game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
