using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(mask.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
