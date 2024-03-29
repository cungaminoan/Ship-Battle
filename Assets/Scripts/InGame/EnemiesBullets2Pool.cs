using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullets2Pool : MonoBehaviour
{
    public static EnemiesBullets2Pool bulletsPoolInstanse;
    [SerializeField] GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletsPoolInstanse = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null && !bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (pooledBullet == null)
        {
            return null;
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        else
        {
            return null;
        }
    }
}