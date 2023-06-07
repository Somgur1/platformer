using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public float maxVerticalAngle = 90f;
    public float minVerticalAngle = -90f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.y = Mathf.Clamp(turn.y, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}