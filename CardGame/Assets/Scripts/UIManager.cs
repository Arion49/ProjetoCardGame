using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Enemy")]
    public Text enemyName;
    public Image enemyImage;

    [Header("Player")]
    public Text playerName;
    public Image playerImage;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
