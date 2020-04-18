using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletFire : MonoBehaviour
{
    [HideInInspector]
    public Vector3 destination;
    public float forceStrength = 200f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(rb == null)
        rb = GetComponent<Rigidbody>();

        transform.LookAt(destination);
        rb.AddRelativeForce(transform.forward * forceStrength);
    }
}
