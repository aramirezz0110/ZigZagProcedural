using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private bool isWalkinkLeft = true;
    private float speedMultiplier = 2f;

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    private RaycastHit hitContact;
    [SerializeField] private Transform rayOrigin;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
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
        if (!IsGrounded())
        {
            myAnimator.SetTrigger(PlayerAnimParams.IsFalling);
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
    private bool IsGrounded()
    {
        if (Physics.Raycast(rayOrigin.position, -transform.up, out hitContact, Mathf.Infinity))
            return true;
        else
            return false;
    }
}
