using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
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
            Vector3 temp = transform.position;
            temp.y+= 0.5f;
            Instantiate(bullets, temp, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            canShoot = true;


        }
            
    }
}
