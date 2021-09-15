using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public Transform firepoint;
    public Transform playerrotation;
    public AudioSource soundSource;
    public AudioSource noAmmo;
    public GameObject bulletPref;
    public int randomRange;
    float fireRate = 1.25f;
    float firetime = 0f;
    int ammoMax;
    int currentAmmo;
    bool gunEnabled = false;
    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        ammoMax = 75;
        currentAmmo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunEnabled == true)
        {
            firetime -= Time.deltaTime;
            if (Input.GetButton("Fire1") && firetime <= 0)
            {
                if(currentAmmo > 1)
                {
                    Shoot();
                    firetime = fireRate;
                }
                else
                {
                    noAmmo.Play();
                }
               
            }
        }
    }
    void Shoot()
    {
        currentAmmo -= 1;
        int spread = Random.Range(-randomRange, randomRange);
        int spread2 = Random.Range(-randomRange, randomRange);
        int spread3 = Random.Range(-randomRange, randomRange);
        int spread4 = Random.Range(-randomRange, randomRange);
        int spread5 = Random.Range(-randomRange, randomRange);

        Quaternion rotSpread = firepoint.rotation * Quaternion.Euler(0, 0, spread);
        Quaternion rotSpread2 = firepoint.rotation * Quaternion.Euler(0, 0, spread2);
        Quaternion rotSpread3 = firepoint.rotation * Quaternion.Euler(0, 0, spread3);
        Quaternion rotSpread4 = firepoint.rotation * Quaternion.Euler(0, 0, spread4);
        Quaternion rotSpread5 = firepoint.rotation * Quaternion.Euler(0, 0, spread5);

        Instantiate(bulletPref, firepoint.position, (rotSpread));
        Instantiate(bulletPref, firepoint.position, (rotSpread2));
        Instantiate(bulletPref, firepoint.position, (rotSpread3));
        Instantiate(bulletPref, firepoint.position, (rotSpread4));
        Instantiate(bulletPref, firepoint.position, (rotSpread5));
        soundSource.Play();
        
    }
    void GunEquip(int x)
    {
        if (x == 2)
        {
            if (gunEnabled == false)
            {
                gunEnabled = true;
                sR.enabled = true;
                if (currentAmmo + 5 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 5;
            }
            else
            {
                if (currentAmmo + 5 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 5;
            }
        }
        else
        {
            gunEnabled = false;
            sR.enabled = false;
        }
    }
}
