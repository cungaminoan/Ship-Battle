using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    private PowerUpSystem wLevelSystem;
    public int weaponLvl;
    public bool companionActive;
    private void Awake()
    {
        instance = this;
        companionActive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        weaponLvl = 1;
        wLevelSystem = GameObject.Find("GamePlayController").GetComponent<PowerUpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void weaponUpgrade()
    {
        if (weaponLvl <= 5)
        {
            weaponLvl++;
            wLevelSystem.WeaponLevelUpdate(weaponLvl);
        }
    }
}
