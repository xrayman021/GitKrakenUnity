using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] AudioClip _hitSound = null;
    public GameObject ragdoll;
    public float hitPower;
    //public Rigidbody hips;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Axe")
        {
            AudioHelper.PlayClip2D(_hitSound, 1);
            GameObject dead = Instantiate(ragdoll, transform.position, transform.rotation);
            dead.GetComponentInChildren<Rigidbody>().AddForce((dead.transform.position - collision.gameObject.transform.position)*hitPower);
            Destroy(gameObject);
        }
    }
}
