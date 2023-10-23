using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float interval = 0.2f;
    float nextShot = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // shooting logic
        if (Time.time >= nextShot)
        {
            audioSource.PlayOneShot(audioClip);
            nextShot = Time.time + interval;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
