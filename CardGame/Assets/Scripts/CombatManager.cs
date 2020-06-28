using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public GameObject enemy;
    public GameObject player;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (enemy != null)
        {
            UIManager.instance.SetStatus();
      
        }
    }


    
}
