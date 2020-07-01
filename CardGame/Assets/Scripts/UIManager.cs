using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Enemy")]
    public Text enemyName;
    [HideInInspector]
    public Image enemyImage;
    public Text enemyCurrentLife;
    public Text enemyMaxLife;

    [Header("Player")]
    public Text playerName;
    [HideInInspector]
    public Image playerImage;
    public Text playerCurrentLife;
    public Text playerMaxLife;

    [Header("Other")]
    public Text turn;
    [SerializeField]
    private float updateSpeedSeconds;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }



    public void SetEnemyStatus()
    {
        enemyName.text = CombatManager.instance.enemy.enemyName;
        enemyImage = CombatManager.instance.enemy.enemyImage;
        enemyCurrentLife.text = CombatManager.instance.enemy.enemyCurrentLife.ToString();
        enemyMaxLife.text = CombatManager.instance.enemy.enemyMaxLife.ToString();
    }

    public void SetPlayerStatus()
    {
        playerName.text = CombatManager.instance.player.playerName;
        playerImage = CombatManager.instance.player.playerImage;
        playerCurrentLife.text = CombatManager.instance.player.playerCurrentLife.ToString();
        playerMaxLife.text = CombatManager.instance.player.playerMaxLife.ToString();
    }

    public void UpdateLifeEnemy()
    {
          StartCoroutine(ChangeToLifeEnemy(CombatManager.instance.enemy.enemyCurrentLife));      
    }

    public void UpdateLifePlayer()
    {
        StartCoroutine(ChangeToLifePlayer(CombatManager.instance.player.playerCurrentLife));
    }

    private IEnumerator ChangeToLifeEnemy(int life)
    {
        int previousLife = int.Parse(enemyCurrentLife.text);
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            enemyCurrentLife.text = ((int)Mathf.Lerp(previousLife, life, elapsed / updateSpeedSeconds)).ToString();
            yield return null;
        }

        enemyCurrentLife.text = life.ToString();
    }

    private IEnumerator ChangeToLifePlayer(int life)
    {
        int previousLife = int.Parse(playerCurrentLife.text);
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            playerCurrentLife.text = ((int)Mathf.Lerp(previousLife, life, elapsed / updateSpeedSeconds)).ToString();
            yield return null;
        }

        playerCurrentLife.text = life.ToString();
    }
}
