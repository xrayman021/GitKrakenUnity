﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxe : MonoBehaviour
{
    public GameObject AxePrefab;
    public Transform launcher;
    private GameObject currentAxe;
    public bool returning;
    public float returnForce;
    private Rigidbody currentAxeRB;
    public float collectDist = 1;

    public MeshRenderer axe;
    public float throwForce = 50;
    public Transform target, curve_point;
    private Vector3 old_pos;
    private bool isReturning = false;
    private float time = 0.0f;

    public Animator animator;
    bool Throw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = gameObject.GetComponent<Animator>();
        Throw = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonUp("Fire1"))
        {
            ThrowAxe();
            Throw = true;
          
        }
        else
        {
            Throw = false;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            ReturnAxe();
        }
        if(returning)
        {
            currentAxe.transform.LookAt(transform.position);
            currentAxeRB.AddForce(currentAxe.transform.forward * returnForce);
            if (currentAxe != null && Vector3.Distance(transform.position, currentAxe.transform.position) < collectDist)
            {
                returning = false;
                ResetAxe();
            }
        }
        if (Throw == false) //Throw animation
            animator.SetBool("Throw", false);

        if (Throw == true)
            animator.SetBool("Throw", true);
        

        /*if(isReturning)
        {
            if(time < 1.0f)
            {
                axe.position = getBQCPoint(time, old_pos, curve_point.position, target.position);
                axe.rotation = Quaternion.Slerp(axe.transform.rotation, target.rotation, 50 * Time.deltaTime);
            }
            else
            {
                ResetAxe();
            }
        } */

    }

    //Throw axe
    void ThrowAxe()
    {
        if (axe.enabled)
        {
            axe.enabled = false;
            currentAxe = Instantiate(AxePrefab, launcher.position, launcher.rotation);
            currentAxeRB = currentAxe.GetComponent<Rigidbody>();
            currentAxeRB.AddForce(launcher.forward * throwForce);
        }


       /*
        isReturning = false;
        axe.transform.parent = null;
        axe.isKinematic = false;
        axe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        axe.AddTorque(axe.transform.TransformDirection(Vector3.right) * 500, ForceMode.Impulse);
        */
    }

    //Return Axe
    void ReturnAxe()
    {
        returning = true;
        currentAxe.transform.parent = null;
        currentAxeRB.velocity = new Vector3(0, 0, 0);
        currentAxe.transform.Find("AxePivot").GetComponent<Spin>().enabled = true;


        /*time = 0.0f;
        old_pos = axe.position;
        isReturning = true;
        axe.velocity = Vector3.zero;
        axe.isKinematic = true;*/
    }
    //Reset Axe
    void ResetAxe()
    {
        axe.enabled = true;
        Destroy(currentAxe);
        /*isReturning = false;
        axe.transform.parent = transform;
        axe.position = target.position;
        axe.rotation = target.rotation;*/
    }
    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }


}
