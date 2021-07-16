using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignWalkOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Sign;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Sign")
        {
            Sign.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sign")
        {
            Sign.SetActive(false);
        }
    }
}
