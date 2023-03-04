using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullStatus : MonoBehaviour
{
    public static HullStatus instance;

    [SerializeField] private GameObject[] Locations;
    [SerializeField] private GameObject SmokeFX;
    [SerializeField] private GameObject FireFX;
    [SerializeField] private GameObject leftSide;
    [SerializeField] private GameObject overShield;
    private static int oldindex;

    private void Awake()
    {
        instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateHullStatus()
    {
        SmokeFX.transform.position= leftSide.transform.position;
        FireFX.transform.position= leftSide.transform.position;
        SmokeFX.transform.parent = null;
        FireFX.transform.parent = null;
        int index = Random.Range(0, 3);
        switch (PlayerHealthManager.instance.currentHealth)
        {
            case 1:
                FireFX.transform.position = Locations[index].transform.position;
                FireFX.transform.parent = Locations[index].transform;
                SmokeFX.transform.position = Locations[oldindex].transform.position;
                SmokeFX.transform.parent = Locations[oldindex].transform;
                break;
            case 2:
                SmokeFX.transform.position = Locations[index].transform.position;
                SmokeFX.transform.parent = Locations[index].transform;
                break;
            case 4:
                Instantiate(overShield, transform.position, Quaternion.identity, transform.parent);
                break;
        }
        oldindex = index;

    }
}
