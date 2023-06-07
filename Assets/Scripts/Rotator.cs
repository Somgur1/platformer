using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + y, 0);
    }
}