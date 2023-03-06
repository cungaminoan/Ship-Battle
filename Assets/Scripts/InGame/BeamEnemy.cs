using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnemy : MonoBehaviour
{
    public BeamAction[] beamActions;
    public Rigidbody2D BeamEnemyRB;
    private int currentAction;
    private float actionCounter;
    private int health;
    private ScoreSystem scoreSystem;

    [SerializeField] private float itemDropPercent;
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private GameObject ShieldHitFX;
    private Vector2 aimDirection, moveDirection;
    public bool isBeaming;
    private Quaternion rotationAngle;
    private float stalkRange;
    private float fireCounter;
   
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject xplosionFX;
    [SerializeField] private GameObject muzzleFX;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        isBeaming = false;
        actionCounter = beamActions[currentAction].actionLength;
        stalkRange = 3.5f;
        scoreSystem = GameObject.Find("GamePlayController").GetComponent<ScoreSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // The enemy can not adjust aim  while shooting LASER BEAM :D
        if (!isBeaming)
        {
            //AIMING :D///////////////////////////////////////////////////////////////////////////////////
            aimDirection = (Ship.instance.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * 57.29578f - 90f; // Calculating the angle to rotate using tan. In Degree :v
            rotationAngle = Quaternion.AngleAxis(angle, Vector3.forward); // Rotation about the Z axis
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * beamActions[currentAction].rotationSpeed);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////            
        }
        // Handles the Actions
        if (actionCounter > 0)
        {
            actionCounter -= Time.deltaTime;
            // Reset the base moveDirection vector each cycle. In case bad things happen
            moveDirection = Vector2.zero;
            if (beamActions[currentAction].shouldStalk)
            {
                
                Stalk();
            }
            if (beamActions[currentAction].shouldShoot)
            {
               
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0) 
                {
                    fireCounter = beamActions[currentAction].timeBetweenBurst;
                    StartCoroutine(BurstFire(beamActions[currentAction].burstSize, beamActions[currentAction].beamType, beamActions[currentAction].fireRate)); 
                }
            }
            if (currentAction == 2) 
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = beamActions[currentAction].timeBetweenBurst;
                    Instantiate(muzzleFX, beamActions[currentAction].muzzlePoint.transform.position, Quaternion.identity, beamActions[currentAction].muzzlePoint.transform);
                }
            }
            if (beamActions[currentAction].shouldBeam)
            {
                isBeaming = true;
                fireCounter-= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = beamActions[currentAction].timeBetweenBurst;
                    StartCoroutine(BurstFire(beamActions[currentAction].burstSize, beamActions[currentAction].beamType, beamActions[currentAction].fireRate));
                }
            }
            moveDirection.Normalize();
            BeamEnemyRB.velocity = moveDirection * beamActions[currentAction].moveSpeed;
        }
        else
        {
            StopAllCoroutines(); // Makes sure that all coroutines are stopped after each actions no matter the timer on the coroutine itself
            if (currentAction != 2)
            {
                currentAction = Random.Range(0, 3); // Randomizes from 1 ~ 2 the tactics(actions) against the Player
            }
            else
            {
                currentAction++; // If currentAction = 2, progress to the next stage (stage 2 and 3 always come together)
            }
            Debug.Log("" + currentAction);
            actionCounter = beamActions[currentAction].actionLength;
            fireCounter = 0.5f;// Set new timers for the new action each step:D
            isBeaming = false; // Update beaming status after each stage
        }
        
        

    }
    private IEnumerator LaserBeam()
    {
        yield return new WaitForSeconds(3f);
        isBeaming = true; Debug.Log("Laser Beam");
        //Instantiate(beamActions[currentAction].beamType, firePoint.position, firePoint.rotation, firePoint.transform);
        //StartCoroutine(waitforSeconds(3));
    }
    private IEnumerator BurstFire(int BurstSize, GameObject bullets, float fireRate)
    {
        moveDirection = Vector2.zero;
        for (int i = 0; i < BurstSize; i++)
        {
            Instantiate(bullets, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(60f / fireRate);
        }
    }
    private void Stalk()
    {
        if (Vector2.Distance(Ship.instance.transform.position, transform.position) > stalkRange)
        {
            moveDirection = Ship.instance.transform.position - transform.position;
        }
        else
        {
            moveDirection = transform.position - Ship.instance.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Bullets")
        {
            DamageEnemy();
        }
        else if (collision.gameObject.tag == "Player Shield")
        {
            DamageEnemy();
            Instantiate(ShieldHitFX, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Player")
        {
            DamageEnemy();
        }
    }
    private void DamageEnemy()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(xplosionFX, transform.position, Random.rotation);
            scoreSystem.updateScore(20);
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }
}

[System.Serializable]
public class BeamAction
{
    [Header("Actions")]
    public float actionLength; // How long the enemy should do each action

    public bool shouldBeam;
    public bool shouldStalk;
    public bool shouldShoot;
    public float moveSpeed;
    
    public float rotationSpeed;
    public GameObject beamType;
    public float timeBetweenBurst;
    public float fireRate;
    public int burstSize;

   
    public Transform muzzlePoint;
}