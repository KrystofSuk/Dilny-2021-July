using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooter : MonoBehaviour
{
    public void Shoot()
    {
        GameObject.FindGameObjectsWithTag("Respawn").First()?.GetComponent<ObjectShooter>().Shoot();
    }
}
