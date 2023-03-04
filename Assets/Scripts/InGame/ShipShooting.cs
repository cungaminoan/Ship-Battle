using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public Transform firePointCenter;
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject MuzzleFX;
    private bool canShoot = true;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }

        }
        IEnumerator Shoot()
        {
            canShoot = false;
            Instantiate(MuzzleFX, firePointCenter.position, firePointCenter.rotation);
            Instantiate(bullets, firePointCenter.position, firePointCenter.rotation);
            yield return new WaitForSeconds(0.2f);
            canShoot = true;


        }
            
    }
}
