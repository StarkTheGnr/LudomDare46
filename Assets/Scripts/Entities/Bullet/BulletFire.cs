using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletFire : MonoBehaviour
{
    [HideInInspector]
    public Vector3 destination;

    [HideInInspector]
    public GameObject player;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Entity")
        {
            Stats enemyStats = collision.gameObject.GetComponent<Stats>();
            Stats playerStats = player.GetComponent<Stats>();

            enemyStats.Health -= playerStats.Damage;
        }
    }
}
