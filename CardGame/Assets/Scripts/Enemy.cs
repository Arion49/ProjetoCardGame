using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName;

    public int enemyMaxLife;

    public int enemyCurrentLife;


    public int enemyDamage;

    public Image enemyImage;

    public bool TakeDamage(int damage)
    {
        enemyCurrentLife -= damage;
        if (enemyCurrentLife <= 0)
        {
            return true;
        }
           
        return false;
    }

    public void RestoreHealth()
    {
        enemyCurrentLife = enemyMaxLife;
    }
 
}
