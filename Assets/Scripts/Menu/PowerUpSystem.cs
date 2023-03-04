using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public TextMeshProUGUI[] WeaponLevel;
    // Start is called before the first frame update
    void Start()
    {
        this.WeaponLevelUpdate(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WeaponLevelUpdate(int level)
    {
        WeaponLevel[0].text = "" + level;
        WeaponLevel[1].text = "" + level;
        WeaponLevel[2].text = "" + level;
    }
}
