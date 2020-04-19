using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshair;
    public float width = 2f, height = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (width / 2);
        float yMin = (Screen.height / 2) - (height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, width, height), crosshair);
    }
}
