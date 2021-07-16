using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PauzaText.SetActive(false);
    }
    private bool isPaused = false;
    // Update is called once per frame
    public GameObject PauzaText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&isPaused==false)
        {
            Time.timeScale = 0;
            isPaused = true;
            PauzaText.SetActive(true);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                Time.timeScale = 1;
                isPaused = false;
                PauzaText.SetActive(false);
            }
        }
    }
}
