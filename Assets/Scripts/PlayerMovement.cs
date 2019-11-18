using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public float walkingSpeed;
    public float runningSpeed;
    public float currentSpeed;

    public GameObject cam;

    private Rigidbody rb;

    void Start()
    {
        cam.SetActive(photonView.IsMine);
        rb = this.GetComponent<Rigidbody>();

        if (!photonView.IsMine)
            gameObject.layer = 9;

    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);

        Vector2 inputDirection;
        inputDirection.x = -Input.GetAxis("LeftJoystickHorizontal");
        inputDirection.y = -Input.GetAxis("LeftJoystickVerticle");

        if (Mathf.Abs(inputDirection.x) < .15)
            inputDirection.x = 0.0f;

        if (Mathf.Abs(inputDirection.y) < .15)
            inputDirection.y = 0.0f;


        this.transform.Translate(Vector3.left * inputDirection.x * Time.deltaTime * currentSpeed);
        this.transform.Translate(Vector3.forward * inputDirection.y * Time.deltaTime * currentSpeed);

    }//end of move

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("AButton"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        }
    }//end of jump

}//end of script