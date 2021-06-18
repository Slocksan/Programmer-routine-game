using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject secondBulletPrefab;

    public float bulletSpeed = 20f;
    public float secondPulletSpeed = 50f;

    public float heavyShootDelay = 1;
    public float lightShootDelay = 0.25f;

    private float lastTimeShoot;


    private void Start()
    {
        lastTimeShoot = 0;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastTimeShoot > lightShootDelay)
                ShootLight();
        }
        else if (Input.GetButton("Fire2"))
        {
            if (Time.time - lastTimeShoot > heavyShootDelay)
                ShootHeavy();
        }
    }
    void ShootLight()
    {
        GameObject tommyGunBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = tommyGunBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        lastTimeShoot = Time.time;
    }

    void ShootHeavy()
    {
        GameObject heavyBullet = Instantiate(secondBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = heavyBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * secondPulletSpeed, ForceMode2D.Impulse);
        lastTimeShoot = Time.time;
    }
}
