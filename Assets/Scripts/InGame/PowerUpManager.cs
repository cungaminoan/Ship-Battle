using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public PilotAction[] actions;

    public int currentPilotAction = 0;
    private float shotCount;
    private float timerCount0,timerCount1;

    [SerializeField] private Rigidbody2D[] pilotShipRBs;
    [SerializeField] private GameObject Bullets;
   
    private Vector2 pilotDirL, pilotDirR;
    private PowerUpSystem wLevelSystem;
    
    public int weaponLvl;
    private void Awake()
    {
        instance = this;
        currentPilotAction = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        timerCount0 = actions[0].actionTimer;
        timerCount1 = actions[1].actionTimer;
        weaponLvl = 1;
        wLevelSystem = GameObject.Find("GamePlayController").GetComponent<PowerUpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentPilotAction)
        {
            case 0:              
                if (timerCount0 > 0)
                {

                    timerCount0 -= Time.deltaTime;
                    pilotHandler(0); // Handle the moving 
                }
                else
                {
                    timerCount0 = actions[0].actionTimer;
                }
                break;
            case 1:
                
                if (timerCount1 > 0)
                {
                    timerCount1 -= Time.deltaTime;
                    pilotHandler(1);
                    this.surpressingFire(); //Handle the shooting
                }
                else
                {
                    wLevelSystem.pilotIcon(0);
                    currentPilotAction = 0; //Always returns to the in active state
                    timerCount1 = actions[1].actionTimer;
                }    
                break;
        }
        
    
    }
    //WEAPON UPGRADE SYSTEM/////////////////////////////////////////////
    public void weaponUpgrade()
    {
        if (weaponLvl <= 5)
        {
            weaponLvl++;
            wLevelSystem.WeaponLevelUpdate(weaponLvl);
        }
    }
    //DEFINE A CLASS THAT CONTAINS A SET OF ACTIONS FOR THE PILOTS/////
    [System.Serializable]
    public class PilotAction
    {
        [Header("Action")]
       
        public float moveSpeed;
       
        public float actionTimer; // How long will the Pilots fight by your side?

        public Transform[] pointToMoveTo;
        public Transform[] firePoints;
    }  
    //MOVING THE PILOTS AROUND////////////////////////////////////////////////////////////////////////////////////
    private void pilotHandler(int currentPilotAction)
    {
        pilotDirL = (actions[currentPilotAction].pointToMoveTo[0].position - pilotShipRBs[0].transform.position);
        pilotDirR = (actions[currentPilotAction].pointToMoveTo[1].position - pilotShipRBs[1].transform.position);
        if (currentPilotAction == 0)
        {
            pilotDirR.Normalize();
            pilotDirL.Normalize();
        }
        pilotShipRBs[0].velocity = pilotDirL * actions[currentPilotAction].moveSpeed;
        pilotShipRBs[1].velocity = pilotDirR * actions[currentPilotAction].moveSpeed;
    }
    // PILOTS GO PEW PEW PEW/////////////////////////////////////////////////////////////////////////////////////
    private void surpressingFire()
    {
        if (shotCount > 0)
        {
            shotCount -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
            {
                //shoot
                Instantiate(Bullets, actions[currentPilotAction].firePoints[0].transform.position, actions[currentPilotAction].firePoints[0].transform.rotation);
                Instantiate(Bullets, actions[currentPilotAction].firePoints[1].transform.position, actions[currentPilotAction].firePoints[1].transform.rotation);
                shotCount = 0.1f;
            }
        }
    }
}
