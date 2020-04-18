using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject firePoint, fireBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(fireBullet, firePoint.transform.position, Quaternion.identity);
            Vector3 point;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {
                point = hit.point;
            }
            else
            {
                point = ray.GetPoint(100f);
            }

            BulletFire bulletFire = bullet.GetComponent<BulletFire>();
            bulletFire.destination = point;
            bulletFire.Fire();
        }
    }
}
