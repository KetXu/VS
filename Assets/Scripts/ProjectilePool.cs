using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool sharedPool;

    [SerializeField] private GameObject projectile;
    [SerializeField] private List<GameObject> projectilePool;
    [SerializeField] private float amountPool;

    private void Awake()
    {
        sharedPool = this;
    }

    private void Start()
    {
        projectilePool = new List<GameObject>();
        GameObject projectileInt;
        for (int i = 0; i < amountPool; i++)
        {
            projectileInt = Instantiate(projectile);
            projectileInt.SetActive(false);
            projectilePool.Add(projectileInt);
        }
    }

    public GameObject GetProjectileInPool()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }

    void InactiveProjectile()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (projectilePool[i].activeInHierarchy)
            {

            }
        }
    }
}
