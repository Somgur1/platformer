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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        WinTextObject.SetActive(false);
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
