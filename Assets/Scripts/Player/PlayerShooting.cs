using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private float shootInterval;

    private float intervalReset;

    void Start()
    {
        intervalReset = shootInterval;  
    }

    void Update()
    {
        shootInterval -= Time.deltaTime;

        if(shootInterval <= 0 )
        {
            Shoot();
            shootInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, shootPosition.position, Quaternion.identity);
    }
}
