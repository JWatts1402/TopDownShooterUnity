using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    public Transform firepoint;
    public Transform playerrotation;
    public GameObject bulletPref;
    public AudioSource soundSource;
    public AudioSource noAmmo;
    public int randomRange;
    float fireRate = 0.2f;
    float firetime = 0f;
    int ammoMax;
    int currentAmmo;
    bool gunEnabled = false;
    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
       
        ammoMax = 500;
        currentAmmo = 175;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunEnabled == true)
        {
            firetime -= Time.deltaTime;
            if (Input.GetButton("Fire1") && firetime <= 0)
            {
                if (currentAmmo > 0)
                {
                    Shoot();
                    soundSource.Play();
                    firetime = fireRate;
                } else
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
        Quaternion rotSpread = firepoint.rotation * Quaternion.Euler(new Vector3(0, 0, spread));
        Instantiate(bulletPref, firepoint.position, (rotSpread));
      
    }
    void GunEquip(int x)
    {
        if (x == 3)
        {
            if (gunEnabled == false)
            {
                gunEnabled = true;
                sR.enabled = true;
                if (currentAmmo + 50 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 50;
            }
            else
            {
                if (currentAmmo + 50 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 50;
            }
        }
        else
        {
            gunEnabled = false;
            sR.enabled = false;
        }
    }
}
