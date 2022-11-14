using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D myBody;
  
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2 (0f,bulletSpeed);
        
    }
}
