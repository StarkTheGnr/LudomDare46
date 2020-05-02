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
        if(other.gameObject.layer == 10)
        {
            Stats stats = other.gameObject.GetComponent<Stats>();
            stats.Health = 0;

            lives--;

            if(lives <= 0)
            {
                EndGame();
                CloseGameAfter(3);
            }
        }
    }

    void EndGame()
    {
        canvas.SetActive(true);
    }

    IEnumerator CloseGameAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.Quit();
    }
}
