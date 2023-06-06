using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public TextMeshProUGUI TimeText;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isTimerOn = false;
    private float time;
    private bool gameCompleted = false;

    public float jumpForce = 550f;
    bool isGrounded;

    public InputActions PlayerControls;

    private InputAction move;
    private InputAction click;

    private void OnEnable()
    {
        move = PlayerControls.Player.Move;
        move.Enable();

        click = PlayerControls.Player.Fire;
        click.Enable();
        click.performed += Click;
    }

  

    private void OnDisable( ) { 
        move.Disable();
        click.Disable();
    }

    private void Awake()
    {
        PlayerControls = new InputActions();
 }

    private void Click(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Click fired");
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce * 1.5f);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Debug.Log("Game started");
        SetCountText();
        WinTextObject.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On collision enter");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        Debug.Log(isGrounded);
    }
    void OnMove(InputValue movementValue)
    {
       
        Vector2 movementVector = movementValue.Get<Vector2>();
        

        movementX = movementVector.x;
        movementY = movementVector.y;

        if(gameCompleted == false && isTimerOn == false)
        {
            isTimerOn = true;
        }

    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinTextObject.SetActive(true);
            isTimerOn = false;
            gameCompleted= true;
        }
    }

    void Update()
    {



        if (isTimerOn)
        {

            time += Time.deltaTime;

            TimeText.text = time.ToString();

        }

    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
        
    }

}
