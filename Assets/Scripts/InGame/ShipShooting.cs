using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] private Transform firePointCenter;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private Transform firePointRight;
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject rockets;
    [SerializeField] private GameObject MuzzleFX;
    [SerializeField] private GameObject MuzzleFX2;
    //private bool canShoot = true;
    public float timeBetweenShots;
    private float shotCount;
    private static float rocketCount;
    private void Start()
    {
  
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        //{
        // Duc: There's nothing wrong here, it's just that I want to implement a system to increase (or decrease) fire rate as a weapon upgrade
        // so I'm commenting it out to implement another way of handling shooting :D
        //    if (canShoot)
        //    {
        //        StartCoroutine(Shoot());
        //    }

        //}
        //IEnumerator Shoot()
        //{
        //    canShoot = false;
        //    //////////////////////////////////////////////////////////////////////////
        //    Instantiate(MuzzleFX, firePointCenter.position, firePointCenter.rotation);
        //    Instantiate(bullets, firePointCenter.position, firePointCenter.rotation);
        //    yield return new WaitForSeconds(0.2f);
        //    canShoot = true;
        //}
        if (shotCount > 0)
        {
            shotCount -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
            {
                //shoot
                PewPewPew();
                shotCount = timeBetweenShots;
            }
        }
        if (PowerUpManager.instance.weaponLvl == 6)
        {
            rocketCount -= Time.deltaTime;
            if (rocketCount <= 0)
            {
                rocketCount = 2f;
                Instantiate(MuzzleFX2, firePointCenter.position, firePointCenter.rotation);
                Debug.Log("MuzzleFX ");
                Instantiate(rockets, firePointCenter.position, firePointCenter.rotation);
                Debug.Log("Homing Missile Launched");
            }
        }
    }
    private void PewPewPew()
    {
        switch (PowerUpManager.instance.weaponLvl)
        {
            case 1:
                Instantiate(MuzzleFX, firePointCenter.position, firePointCenter.rotation);
                Instantiate(bullets, firePointCenter.position, firePointCenter.rotation);
                break;
            case 2:
                Instantiate(MuzzleFX, firePointCenter.position, firePointCenter.rotation);
                Instantiate(bullets, firePointCenter.position, firePointCenter.rotation);
                timeBetweenShots = 0.6f;
                break;
            case 3:
                Instantiate(MuzzleFX, firePointLeft.position, firePointLeft.rotation);
                Instantiate(bullets, firePointLeft.position, firePointLeft.rotation);
                Instantiate(MuzzleFX, firePointRight.position, firePointRight.rotation);
                Instantiate(bullets, firePointRight.position, firePointRight.rotation);
                break;
            case 4:
                Instantiate(MuzzleFX, firePointLeft.position, firePointLeft.rotation);
                Instantiate(bullets, firePointLeft.position, firePointLeft.rotation);
                Instantiate(MuzzleFX, firePointRight.position, firePointRight.rotation);
                Instantiate(bullets, firePointRight.position, firePointRight.rotation);
                timeBetweenShots = 0.45f;
                break;
            case 5:
                Instantiate(MuzzleFX, firePointCenter.position, firePointCenter.rotation);
                Instantiate(bullets, firePointCenter.position, firePointCenter.rotation);
                Instantiate(MuzzleFX, firePointLeft.position, firePointLeft.rotation);
                Instantiate(bullets, firePointLeft.position, firePointLeft.rotation);
                Instantiate(MuzzleFX, firePointRight.position, firePointRight.rotation);
                Instantiate(bullets, firePointRight.position, firePointRight.rotation);
                break;   
              case 6:
                timeBetweenShots = 0.28f;
                Instantiate(MuzzleFX, firePointLeft.position, firePointLeft.rotation);
                Instantiate(bullets, firePointLeft.position, firePointLeft.rotation);
                Instantiate(MuzzleFX, firePointRight.position, firePointRight.rotation);
                Instantiate(bullets, firePointRight.position, firePointRight.rotation);
                break;
            default: 
                break;
        }
    }
}
