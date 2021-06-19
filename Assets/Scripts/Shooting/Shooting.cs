using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject secondBulletPrefab;

    public int lightGunDamageBonus = 0;
    public int heavyGunDamageBonus = 0;
    
    public float bulletSpeed = 20f;
    public float secondPulletSpeed = 50f;

    public float heavyShotsPerMinute = 60;
    public float lightShotsPerMinute = 240;

    private float lastTimeShoot;


    private void Start()
    {
        lastTimeShoot = 0;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastTimeShoot > 60 / lightShotsPerMinute)
                ShootLight();
        }
        else if (Input.GetButton("Fire2"))
        {
            if (Time.time - lastTimeShoot > 60 / heavyShotsPerMinute)
                ShootHeavy();
        }
    }
    void ShootLight()
    {
        GameObject tommyGunBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = tommyGunBullet.GetComponent<Rigidbody2D>();
        
        var damage = tommyGunBullet.GetComponent<CollisionDamage>();
        damage.collisionDamage = 3 + lightGunDamageBonus;
        
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        lastTimeShoot = Time.time;
    }

    void ShootHeavy()
    {
        GameObject heavyBullet = Instantiate(secondBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = heavyBullet.GetComponent<Rigidbody2D>();

        var damage = heavyBullet.GetComponent<CollisionDamage>();
        damage.collisionDamage = 10 + heavyGunDamageBonus;
        
        rb.AddForce(firePoint.up * secondPulletSpeed, ForceMode2D.Impulse);
        lastTimeShoot = Time.time;
    }
}
