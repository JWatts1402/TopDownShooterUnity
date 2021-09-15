using UnityEngine;
using UnityEngine.Audio;

public class PistolScript : MonoBehaviour
{
    public Transform firepoint;
    public Transform playerrotation;
    public GameObject bulletPref;
    public AudioSource soundSource;
    public AudioSource noAmmo;
    public int randomRange;
    int ammoMax;
    int currentAmmo;
    bool gunEnabled = false;
    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        soundSource.playOnAwake = false;
        ammoMax = 300;
        currentAmmo = 125;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunEnabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentAmmo > 0)
                {
                    Shoot();
                    soundSource.Play();
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
        Quaternion rotSpread = firepoint.rotation * Quaternion.Euler(0, 0, spread);
        Instantiate(bulletPref, firepoint.position, (rotSpread));
  
    }
    void GunEquip(int x)
        {
            if (x == 1)
            {
            if (gunEnabled == false)
            {
                gunEnabled = true;
                sR.enabled = true;
                if (currentAmmo + 30 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 30;
            }
            else
            {
                if (currentAmmo + 30 > ammoMax) currentAmmo = ammoMax;
                else currentAmmo += 30;               
            }
            }
            else
            {
                gunEnabled = false;
                sR.enabled = false;
            }
        }
    }
