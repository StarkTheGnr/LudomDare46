using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject toSpawn;

    [SerializeField]
    bool spawnWithColliderRotation = false;

    private void OnCollisionEnter(Collision collision)
    {
        Quaternion rot = (spawnWithColliderRotation) ? collision.gameObject.transform.rotation : transform.rotation;
        GameObject obj = Instantiate(toSpawn, collision.GetContact(0).point, Quaternion.identity);

        Destroy(gameObject);
    }
}
