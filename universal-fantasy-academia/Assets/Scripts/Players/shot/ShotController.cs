using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject shot;
    public float fireRate = 0.5F;
    public float nextFire = 0.0F;

    public void Shooter()
    {
        Instantiate(shot, transform.position, transform.rotation);
    }
}
