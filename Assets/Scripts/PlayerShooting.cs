using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform firePosition;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private PlayerMovements playerMovements;

    [SerializeField] private float fireRate;
    private float lastFire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject bullet = Instantiate(projectile, firePosition.position, firePosition.rotation);
            GameObject bullet = ProjectilePool.sharedPool.GetProjectileInPool();
            if (bullet != null)
            {
                bullet.transform.position = firePosition.position;
                bullet.transform.rotation = firePosition.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().AddForce(playerMovements.GetDirection() * projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }

    void AutoFire()
    {
        if (Time.time - lastFire > 1 / fireRate)
        {
            lastFire = Time.time;
            GameObject bullet = Instantiate(projectile, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(playerMovements.GetDirection() * projectileSpeed, ForceMode2D.Impulse);
        }
    }
}
