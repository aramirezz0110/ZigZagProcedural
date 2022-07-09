using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private GameObject crystalParticle;


    private bool isWalkinkLeft = true;
    private float speedMultiplier = 2f;

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    private GameManager gameManagerInstance;
    private RaycastHit hitContact;
    

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        
    }
    private void Start()
    {
        gameManagerInstance = GameManager.Instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }
        if (!IsGrounded())
        {
            myAnimator.SetTrigger(PlayerAnimParams.Falling);
            if (IsInDeadZone())
            {
                gameManagerInstance.FinishGame();
            }
        }         
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (!gameManagerInstance.gameStarted)
            return;

        myRigidbody.transform.position = transform.position + transform.forward * speedMultiplier * Time.deltaTime;
        myAnimator.SetTrigger(PlayerAnimParams.Running);
    }
    private void ChangeDirection()
    {
        if (!gameManagerInstance.gameStarted)
            return;

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
    private bool IsInDeadZone()
    {
        if (transform.position.y < -2)
            return true;
        else
            return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == GameTags.Crystal)
        {
            gameManagerInstance.IncreaseScore();            

            GameObject tempInstance = Instantiate(crystalParticle, rayOrigin.position, Quaternion.identity);
            Destroy(tempInstance, 2f);
            Destroy(other.gameObject);
        }
    }
}
