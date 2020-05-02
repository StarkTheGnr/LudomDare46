using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAndBack : MonoBehaviour
{
    [SerializeField]
    float yStart, yEnd, delay, speed;

    [SerializeField]
    bool xOnly = false, zOnly = false;


    bool goingUp = true;
    float timeReached = 0;

    Rigidbody rb;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (xOnly)
            vel = new Vector3(speed, 0, 0);
        else if (zOnly)
            vel = new Vector3(0, 0, speed);
        else
            vel = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeReached == 0)
        {
            float moveSign = (goingUp) ? 1 : -1;
            rb.velocity = moveSign * vel;

            float currCoord = 0;
            if (xOnly)
                currCoord = transform.localPosition.x;
            else if (zOnly)
                currCoord = transform.localPosition.z;
            else
                currCoord = transform.localPosition.y;

            if ((goingUp && currCoord > (yEnd - 0.02f)) || (!goingUp && currCoord < (yStart + 0.02f)))
            {
                timeReached = Time.time;
                rb.velocity = Vector3.zero;
            }
        }

        if(timeReached != 0)
        {
            float diff = Time.time - timeReached;
            if(diff >= delay)
            {
                timeReached = 0;
                goingUp = !goingUp;
            }
        }
    }
}
