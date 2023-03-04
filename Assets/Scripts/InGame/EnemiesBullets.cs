using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullets : MonoBehaviour
{
    [SerializeField] private float enemiesBulletSpeed;
    [SerializeField] private GameObject ShieldHitFX;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myBody.velocity = transform.right * enemiesBulletSpeed;

    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player Shield")
        {
            Debug.Log("Not Player Hit");
            Instantiate(ShieldHitFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
