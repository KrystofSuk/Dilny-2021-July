using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerS2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 0, -10);
    }
}
