using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets3 : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    //Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1f, 0.1f);
    }

    private void Fire()
    {
        
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);


            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = EnemiesBullets2Pool.bulletsPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemiesBullets2>().SetMoveDirection(bulDir);

            angle += 10f;
    }
}
