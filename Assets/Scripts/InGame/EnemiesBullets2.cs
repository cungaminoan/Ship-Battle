using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBullets2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject ShieldHitFX;
    private Vector2 moveDirection;
    private void OnEnable()
    {
        Invoke("Destroy", 5f);
    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;

    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player Hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player Shield")
        {
            //Debug.Log("Not Player Hit");
            Instantiate(ShieldHitFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
