using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverShield : MonoBehaviour
{
    [SerializeField] private Animator Anim;
    private bool invincible = false; // skips a " ! " :D
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void ShieldCharged()
    {
        Anim.SetBool("isInvincible", false);
        invincible = true;
        // This skips an operation down the line, although the code is a bit hard to make out at first :D
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && invincible)
        {

            DamageShield();
        }
        else if (collision.gameObject.tag == "Enemy Bullets" && invincible)
        {
            DamageShield();
        }
    }
    private void DamageShield()
    {
        health--;
        if (health <= 0)
        {
            PlayerHealthManager.instance.currentHealth = 3; // Resets the Player's HP to "Healthy state" after losing the shield
            Destroy(gameObject);
        }
    }
}
