using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool done = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && done == false)
        {
            Time.timeScale = 0;
            done = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && done == true)
            {
                Time.timeScale = 1;
                done = false;
            }
        }
    }
}
