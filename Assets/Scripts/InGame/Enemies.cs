using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private float enemySpeed;
    private Rigidbody2D myBody;
    [SerializeField] private GameObject bullets;
    private ScoreSystem scoreSystem;
    public float timeBetweenBurst;
    private float fireCounter;
    public int BurstSize;
    public float fireRate;
    public int health;



    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    //    StartCoroutine(EnemiesShoot());
        scoreSystem = GameObject.Find("GamePlayController").GetComponent<ScoreSystem>();

    }

    private void Update()
    {
        myBody.velocity = new Vector2(0f, -enemySpeed);
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = timeBetweenBurst;
            StartCoroutine(BrstFire(BurstSize));
        }
        
    }
    //void FixedUpdate()
    //{
    //    myBody.velocity = new Vector2(0f, -enemySpeed);
    //}
    //void Shoot()
    //{
    //    Instantiate(bullets, firePoint.position, firePoint.rotation);
    //}
    //IEnumerator EnemiesShoot()
    //{
    //    yield return new WaitForSeconds(Random.Range(0.2f, 1.0f));
    //    this.Shoot();
    //    StartCoroutine(EnemiesShoot());
    //}
    private IEnumerator BrstFire (int BurstSize)
    {
        for (int i = 0; i < BurstSize; i++)
        {
            Instantiate(bullets, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(60f/fireRate);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DamageEnemy();
        }
    }
    private void DamageEnemy()
    {
        health --;
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreSystem.updateScore(5);
        }
    }
}
