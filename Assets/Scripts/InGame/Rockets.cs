using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    private Transform target;
    private Vector2 direction;
    private float speed = 6;
    private float angleChangingSpeed = 400;  // OP MISSILES :D
    [SerializeField] private Rigidbody2D RocketRGBody;
    private Quaternion rotatetoTarget;
    
    // Start is called before the first frame update
    void Start()
    { 
            target = findClosestEnemy().transform;
            Destroy(gameObject, 3f); // Auto explodes 3 seconds after launching
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If no target is present at the time of launching, behave like a non-homing missile
        if (target != null)
        {
            direction = target.position - transform.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            RocketRGBody.angularVelocity = -angleChangingSpeed * rotateAmount;
            RocketRGBody.velocity = transform.up * speed;
        }
        else
        {
            RocketRGBody.velocity = transform.up * speed;
        }
    }
    private GameObject findClosestEnemy ()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemies");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) 
        { 
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        //Debug.Log("Closest Enemy Found!");
        return closest;
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
    }
}
