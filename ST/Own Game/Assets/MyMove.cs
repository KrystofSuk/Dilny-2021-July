using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{
    public float playerSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector2(playerSpeed*Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector2(-playerSpeed*Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(new Vector2(0, playerSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(new Vector2(0, -playerSpeed * Time.deltaTime));
        }
    }
}
