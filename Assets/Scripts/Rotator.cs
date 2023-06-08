using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotator : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed;
    private InputActions controls;

    private float xRotatation;

    public InputActions PlayerControls;
    private Vector2 mouselook;
    private InputAction look;
    public Transform playerBody;


    //private void Awake()
    //{
    //    controls = new InputActions();
        

    //}
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //controls.Enable();
        
    }

    

    void Update()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        //float y = Mouse.current.delta.y.ReadValue();
        player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + y, 0);
    }

    //public void Look()
    //{
    //    mouselook = controls.Player.Look.ReadValue<Vector2>();
    //    float mouseX = mouselook.x * turnSpeed * Time.deltaTime;
    //    float mouseY = mouselook.y * turnSpeed * Time.deltaTime;

    //    xRotatation += mouseY;
    //    xRotatation = Mathf.Clamp(xRotatation, -90f, 90);

    //    transform.localRotation = Quaternion.Euler(xRotatation, 0, 0);
    //    playerBody.Rotate(Vector3.up * mouseX);
    //}
}