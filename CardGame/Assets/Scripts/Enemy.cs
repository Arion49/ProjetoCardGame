using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName;

    public int enemyMaxLife;

    public int enemyCurrentLife;
    public int EnemyCurrentLife
    {
        get
        {
            return enemyCurrentLife;
        }
        set
        {
            enemyCurrentLife = value;
            if (enemyCurrentLife <= 0)
            {
                Destroy(gameObject);
                enemyCurrentLife = 0;
                UIManager.instance.UpdateLife();

            }
        }
    }

    public int enemyDamage;

    public Image enemyImage;

    public void TakeDamage(int damage)
    {
        EnemyCurrentLife -= damage;
    }
}
