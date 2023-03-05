using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnemy : MonoBehaviour
{
    public Rigidbody2D BeamEnemyRB;
    public float moveSpeed;
    public float rotatationSpeed;
    private Vector2 aimDirection;
    private bool isBeaming = false;
    private Quaternion rotationAngle;
    private int rangeFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //Randomizes the distance that will follow the Player each spawn
    }

    // Update is called once per frame
    void Update()
    {
        //AIMING THE WEAPON :D///////////////////////////////////////////////////////////////////////////////////
        aimDirection = (Ship.instance.transform.position - BeamEnemyRB.transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * 57.29578f - 90f; // Calculating the angle to rotate using tan :v
        rotationAngle = Quaternion.AngleAxis(angle, Vector3.forward); // Rotation about the Z axis
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotatationSpeed);
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
