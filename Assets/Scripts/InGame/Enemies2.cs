using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float itemDropPercent;
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private GameObject ShieldHitFX;
    private bool moveRight;
    private Rigidbody2D myBody;
    private ScoreSystem scoreSystem;
    public int health;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
     void Start()
    {
        moveRight = true;
        scoreSystem = GameObject.Find("GamePlayController").GetComponent<ScoreSystem>();
    }
    void Update()
    {
        if (transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Bullets")
        {
            DamageEnemy();
        }
        else if (collision.gameObject.tag == "Player Shield")
        {
            DamageEnemy();
            Instantiate(ShieldHitFX, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Player")
        {
            DamageEnemy();
        }

    }
    private void DamageEnemy()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreSystem.updateScore(10);
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }
}
