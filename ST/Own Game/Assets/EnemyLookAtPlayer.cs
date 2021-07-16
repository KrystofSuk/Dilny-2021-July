using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position, Vector3.forward);
        var rot = transform.rotation;
        transform.rotation = rot * Quaternion.Euler(90, 0, 90);
    }
}
