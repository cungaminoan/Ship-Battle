using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotPickUp : MonoBehaviour
{
    private float waitToBeCollected = 0.5f;
    private PowerUpSystem pilotsHere;
    // Start is called before the first frame update
    void Start()
    {
        pilotsHere = GameObject.Find("GamePlayController").GetComponent<PowerUpSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && waitToBeCollected <= 0)
        {
            if (PowerUpManager.instance.currentPilotAction==0)
            {
                pilotsHere.pilotIcon(1);
                PowerUpManager.instance.currentPilotAction = 1;
                Destroy(gameObject);
            }
        }
    }
}
