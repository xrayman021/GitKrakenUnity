using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxe : MonoBehaviour
{
    public Rigidbody axe;
    public float throwForce = 50;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            ThrowAxe();
        }
    }

    //Throw axe
    void ThrowAxe()
    {
        axe.transform.parent = null;
        axe.isKinematic = false;
        axe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        axe.AddTorque(axe.transform.TransformDirection(Vector3.right) * 500, ForceMode.Impulse);
    }

    //Return Axe
    //Reset Axe

}
