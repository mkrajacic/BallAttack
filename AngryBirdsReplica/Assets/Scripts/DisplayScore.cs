using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    void Start()
    {
      int damageToEnemies = PlayerPrefs.GetInt("DamageToEnemies");
      int damageToBricks = PlayerPrefs.GetInt("DamageToBricks");

        if (PlayerPrefs.GetInt("ExtraLifes") == 1)
        {
            damageToEnemies += 1000;
        }
        else if (PlayerPrefs.GetInt("ExtraLifes") == 2)
        {
            damageToEnemies += 2000;
        }
        int overallDamage = (int)damageToEnemies + (int)damageToBricks;

        GetComponent<Text>().text = overallDamage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int damageToEnemies = PlayerPrefs.GetInt("DamageToEnemies");
        int damageToBricks = PlayerPrefs.GetInt("DamageToBricks");

        if (PlayerPrefs.GetInt("ExtraLifes") == 1)
        {
            damageToEnemies += 1000;
        }
        else if (PlayerPrefs.GetInt("ExtraLifes") == 2)
        {
            damageToEnemies += 2000;
        }
        int overallDamage = (int)damageToEnemies + (int)damageToBricks;

        GetComponent<Text>().text = overallDamage.ToString();
    }

}
