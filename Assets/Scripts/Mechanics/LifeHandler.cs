using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    float lives = 30;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Entity")
        {
            Destroy(other.gameObject);

            lives--;

            if(lives <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        canvas.SetActive(true);
    }
}
