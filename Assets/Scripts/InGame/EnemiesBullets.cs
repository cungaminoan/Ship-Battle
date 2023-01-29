using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullets : MonoBehaviour
{
    [SerializeField] private float enemiesBulletSpeed;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, -enemiesBulletSpeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Destroy Player");
            Destroy(gameObject);
        }

    }
}
