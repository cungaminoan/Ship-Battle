using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSystem : MonoBehaviour
{
    public Image abilityImage, pilotImage;
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

    //WEAPON UPGRADE SYSTEM////////////////////////////////////////////////////////////////
    public void WeaponLevelUpdate(int level)
    {
        WeaponLevel[0].text = "" + level;
        WeaponLevel[1].text = "" + level;
        WeaponLevel[2].text = "" + level;
    }

    //DEFENSIVE ABILITY SYSTEM/////////////////////////////////////////////////////////////
    public void AbilityIcon()
    {
        // Flashes the Ability Icon to indicate that it's charging
        StartCoroutine(flashIcon());
    }
    private IEnumerator flashIcon()
    {
        // Flashes the Ability Icon 20 times = 20 seconds in total?
        for (int i = 0; i < 15; i++)
        {
            abilityImage.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            abilityImage.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    //COMPANION PILOTS//////////////////////////////////////////////////////////////////////
    public void pilotIcon(int currentPilotAction)
    {
        if (currentPilotAction == 1)
            pilotImage.gameObject.SetActive(true);
        else
            pilotImage.gameObject.SetActive(false);
    }
}
