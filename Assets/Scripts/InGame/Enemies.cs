using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    private Rigidbody2D myBody;
    [SerializeField] private GameObject bullets;
    private ScoreSystem scoreSystem;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

        StartCoroutine(EnemiesShoot());
        scoreSystem = GameObject.Find("GamePlayController").GetComponent<ScoreSystem>();

    }


    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, -enemySpeed);

    }
    void Shoot()
    {
        Vector3 temp = transform.position;
        temp.y -= 0.2f;
        Instantiate(bullets, temp, Quaternion.identity);
    }
    IEnumerator EnemiesShoot()
    {

        yield return new WaitForSeconds(Random.Range(0.2f, 1.0f));
        this.Shoot();
        StartCoroutine(EnemiesShoot());

    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreSystem.updateScore(5);
        }

    }
}
