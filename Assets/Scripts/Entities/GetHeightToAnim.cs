using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeightToAnim : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;

    [SerializeField]
    Transform raycastOrigin;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(raycastOrigin.position, -transform.up);
        Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10f, layer))
        {
            anim.SetFloat("Height", hit.distance);
        }
    }
}
