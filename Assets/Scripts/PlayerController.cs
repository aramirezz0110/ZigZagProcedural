using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private bool isWalkinkLeft=true;
    private float speedMultiplier = 2f;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        myRigidbody.transform.position = transform.position + transform.forward * speedMultiplier * Time.deltaTime;
    }
    private void ChangeDirection()
    {
        isWalkinkLeft = !isWalkinkLeft;

        if (isWalkinkLeft)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}
