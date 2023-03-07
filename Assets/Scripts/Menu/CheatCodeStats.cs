using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeStats : MonoBehaviour
{
    public static CheatCodeStats instance;
    public float cooldown;
    private void Awake()
    {
        instance= this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
