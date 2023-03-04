using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance;
    public int currentHealth;
    private float iCount, iFrames = 2f; // iFrames is the time that the Player becomes invincible after receiving damage :D
    // Start is called before the first frame update

    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        currentHealth = 3;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (iCount > 0)
        {
            iCount -= Time.deltaTime;
        }
    }
    public void DamagePlayer()
    {
        if (iCount <= 0)
        {
            // -1 HP each time the Player gets hit
            currentHealth--;
            iCount = iFrames;
            // updateHullStatus();
            HullStatus.instance.updateHullStatus();
            StartCoroutine(flashPlayer());
            if (currentHealth <=0)
            {
                Ship.instance.gameObject.SetActive(false);
                GameController.instance.ShipDead();
            }
        }
    }
    public void HealPlayer()
    {
        // Only 4 states of Damage: 4 = Outer Shield, 3 = Normal, 2 = Doomed, 1 = Minor Damage
        if (currentHealth <= 3)
        {
            currentHealth++;
            //updateHullStatus();
            HullStatus.instance.updateHullStatus();
        }
    }
    
    private IEnumerator flashPlayer()
    {
        // Flashes the Ship 5 times
        for (int i = 0; i < 5; i++)
        {
            Ship.instance.shipSR.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            Ship.instance.shipSR.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
