using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public float rotationSpeed;
    private float rotX, rotY;

    void Start()
    {
        rotX = rotY = 0.0f;    
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }


    void Rotation()
    {
        //controls the rotation
        //rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        //rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;

        Vector2 aroundAndUp;
        aroundAndUp.y = Input.GetAxis("RightJoystickHorizontal") * Time.deltaTime * rotationSpeed;
        aroundAndUp.x = Input.GetAxis("RightJoystickVerticle") * Time.deltaTime * rotationSpeed;

        if (Mathf.Abs(aroundAndUp.x) < .15f)
            aroundAndUp.x = 0.0f;

        if (Mathf.Abs(aroundAndUp.y) < .15f)
            aroundAndUp.y = 0.0f;

        rotY += aroundAndUp.y;
        rotX += aroundAndUp.x;

        //clamps the rotx
        if (rotX < -90)
            rotX = -90;
        else if (rotX > 90)
            rotX = 90;

        //updates rotation
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }

}
