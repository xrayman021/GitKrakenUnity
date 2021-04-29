using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Rigidbody rb;
    public Spin spinner;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            transform.parent = collision.transform;
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            spinner.enabled = false;
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
    void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Wall")
            {
                if (rb != null)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.angularVelocity = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
