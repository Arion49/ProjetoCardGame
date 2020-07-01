using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    // FAZER CAIXAS DE DIALOGOS PARA INIMIGOS E PARA O PLAYER

    public static CombatManager instance;

    [Header("Player")]
    public GameObject playerPrefab;
    public Transform playerSpawn;
    [HideInInspector]
    public Player player;

    [Header("Enemy")]
    public GameObject enemyPrefab;
    public Transform enemySpawn;
    [HideInInspector]
    public Enemy enemy;

    // [Header("Others")]


    public enum BattleState
    {
        START, PLAYERTURN, ENEMYTURN, WON, LOST
    }

    public BattleState state;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        state = BattleState.START;

        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        player = playerGO.GetComponent<Player>();
        UIManager.instance.SetPlayerStatus();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemy = enemyGO.GetComponent<Enemy>();
        UIManager.instance.SetEnemyStatus();

        yield return new WaitForSeconds(2f);

        UIManager.instance.turn.text = "SEU TURNO";
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    #region PLAYER
    void PlayerTurn()
    {
        UIManager.instance.turn.text = "SEU TURNO";
        //fazer algo, como uma caixa de diálogo com alguma frase
    }

    public void OnUseADamageCard()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemy.TakeDamage(player.playerDamage); //Como se usasse uma carta
        UIManager.instance.UpdateLifeEnemy();

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    #endregion

    IEnumerator EnemyTurn()
    {
        UIManager.instance.turn.text = "TURNO DO OPONENTE";
        Debug.Log("O inimigo te ataca");

        yield return new WaitForSeconds(1f);

        bool isDead = player.TakeDamage(enemy.enemyDamage);
        UIManager.instance.UpdateLifePlayer();

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }
    void EndBattle()
    {
        UIManager.instance.turn.text = "ACABOU";
        if (state == BattleState.WON)
        {
            Debug.Log("Você ganhou !");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("Você perdeu !");
        }
    }


}
