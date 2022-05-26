using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fullscreen"))
        {
            //toggles fs
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
