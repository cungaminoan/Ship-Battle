using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float itemDropPercent;
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private GameObject ShieldHitFX;
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
        health --;
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreSystem.updateScore(5);
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }
}
