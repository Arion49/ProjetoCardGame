using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string playerName;

    public int playerMaxLife;

    public int playerCurrentLife;


    public int playerDamage;

    public Image playerImage;

    public bool TakeDamage(int damage)
    {
        playerCurrentLife -= damage;
        if (playerCurrentLife <= 0)
        {
            return true;
        }

        return false;
    }
}
