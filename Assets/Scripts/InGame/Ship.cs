using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;
    [SerializeField] private float shipSpeed;
    [SerializeField] private float shipTurnSpeed;
    [SerializeField] private GameObject shockBlast;

    private PowerUpSystem AbilityIcon;
    public float cooldown, currentCoolDown;
    private float horizontalInput;
    private float verticalInput;
    public Rigidbody2D myBody;
    public SpriteRenderer shipSR;
    public bool abilityActive;

    private void Awake()
    {
        abilityActive = true;
        cooldown = 0;
        currentCoolDown = CheatCodeStats.instance.cooldown;
        instance = this;
    }
    private void Start()
    {
        
        AbilityIcon = GameObject.Find("GamePlayController").GetComponent<PowerUpSystem>();
    }
    private void Update()
    {
        this.ShipMov();
        this.ShipDefend();
        if (cooldown <=0 ) 
        { 
            abilityActive = true; 
        }
    }

    protected void ShipMov()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * Time.deltaTime * shipSpeed * verticalInput);
        transform.Translate(Vector2.right * Time.deltaTime * shipTurnSpeed * horizontalInput);
    }
    // The ability to defend the ship. As of now, it's an shockwave blast :D
    protected void ShipDefend()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
        // Ability here 
        cooldown = currentCoolDown; 
        Debug.Log("Shock wave cool down");
        Instantiate(shockBlast, transform.position, transform.rotation);
        AbilityIcon.AbilityIcon();
        abilityActive = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.tag == "Enemies")
        {
            //Debug.Log("Collision detected!");
            PlayerHealthManager.instance.DamagePlayer(); 
        }
        else if (collision.gameObject.tag == "Enemy Bullets")
        {
            PlayerHealthManager.instance.DamagePlayer();
        }

    }
}
