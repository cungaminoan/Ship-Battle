using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance;
    public int currentHealth;
    private float iCount, iFrames = 2f; // iFrames is the time that the Player becomes invincible after receiving damage :D
    [SerializeField] private GameObject SmokeFX;
    [SerializeField] private GameObject FireFX;
    [SerializeField] private GameObject[] hullDamages;

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
            updateHullStatus();
            StartCoroutine(flashPlayer());
        }
    }
    private void updateHullStatus()
    {
        switch (currentHealth)
        {
            case 0:
                Ship.instance.gameObject.SetActive(false);
                GameController.instance.ShipDead();
                break;
            case 1:
                // Fire FX
                HullDamage(FireFX);
                break;
            case 2:
                // Smoke FX
                HullDamage(SmokeFX);
                break;
            case 4:
                // Shield :D
                break;
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
    private void HullDamage(GameObject Effects)
    {
        int index = Random.Range(0, 3);
        Instantiate(Effects, hullDamages[index].transform.position, hullDamages[index].transform.rotation, hullDamages[index].transform.parent);
    }
}
