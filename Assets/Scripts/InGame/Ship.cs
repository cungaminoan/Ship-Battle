using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;
    [SerializeField] private float shipSpeed;
    [SerializeField] private float shipTurnSpeed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D myBody;
    public SpriteRenderer shipSR;

    private void Awake()
    {
        instance= this;
    }
    private void FixedUpdate()
    {
        this.ShipMov();
    }

    protected void ShipMov()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * Time.deltaTime * shipSpeed * verticalInput);
        transform.Translate(Vector2.right * Time.deltaTime * shipTurnSpeed * horizontalInput);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.tag == "Enemies")
        {
            //Debug.Log("Collision detected!");
            PlayerHealthManager.instance.DamagePlayer(); 
        }

    }
}
