﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject firePoint, fireBullet;

    public AudioSource gunFire;

    [SerializeField]
    Transform Gun;

    [SerializeField]
    LayerMask layerToHit;

    [SerializeField]
    float fireRate = 0.5f;

    float lastFired = 0f;

    [SerializeField]
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, layerToHit))
        {
            point = hit.point;
        }
        else
        {
            point = ray.GetPoint(100f);
        }

        Gun.LookAt(point);

        if (Input.GetButton("Fire1") && (Time.time - lastFired > fireRate))
        {
            anim.SetTrigger("FireAgain");
            anim.SetBool("Fire", true);

            GameObject bullet = Instantiate(fireBullet, firePoint.transform.position, Quaternion.identity);
            bullet.transform.LookAt(point);

            BulletFire bulletFire = bullet.GetComponent<BulletFire>();
            bulletFire.destination = point;
            bulletFire.player = gameObject;
            bulletFire.Fire();
            gunFire.Play();

            lastFired = Time.time;
        }
    }
}
