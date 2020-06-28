using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public GameObject enemy;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (enemy != null)
        {
            UIManager.instance.enemyName.text = enemy.GetComponent<Enemy>().enemyName;
            UIManager.instance.enemyImage = enemy.GetComponent<Enemy>().enemyImage; 
      
        }
    }


    
}
