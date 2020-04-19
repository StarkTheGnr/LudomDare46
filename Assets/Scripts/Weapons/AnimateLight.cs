using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLight : MonoBehaviour
{
    [SerializeField]
    float minIntensity, maxIntensity, glowSpeed;

    [SerializeField]
    Light lightObj;

    bool increasing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!increasing)
        {
            lightObj.intensity = Mathf.Lerp(lightObj.intensity, maxIntensity, glowSpeed * Time.deltaTime);

            if (lightObj.intensity > (maxIntensity - 0.2f))
                increasing = true;
        }
        else
        {
            lightObj.intensity = Mathf.Lerp(lightObj.intensity, minIntensity, glowSpeed * Time.deltaTime);

            if (lightObj.intensity < (minIntensity + 0.2f))
                increasing = false;
        }
    }
}
