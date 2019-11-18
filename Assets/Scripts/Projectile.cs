using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 50f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Destroy(this.gameObject, 2.5f);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "otherPlayer")
        {
            Debug.Log("I hit that guy");
            //collision.gameObject.GetComponent<Health>().health -= 5;
            Destroy(this.gameObject);
        }
    }//end of OnCOllisionEnter

}
