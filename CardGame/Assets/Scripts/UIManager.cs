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
    public Text enemyCurrentLife;
    public Text enemyMaxLife;

    [Header("Player")]
    public Text playerName;
    public Image playerImage;

    [Header("Other")]
    [SerializeField]
    private float updateSpeedSeconds;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CombatManager.instance.enemy.GetComponent<Enemy>().TakeDamage(100);
            UpdateLife();
        }
    }

    public void SetStatus()
    {
        enemyName.text = CombatManager.instance.enemy.GetComponent<Enemy>().enemyName;
        enemyImage = CombatManager.instance.enemy.GetComponent<Enemy>().enemyImage;
        enemyCurrentLife.text = CombatManager.instance.enemy.GetComponent<Enemy>().EnemyCurrentLife.ToString();
        enemyMaxLife.text = CombatManager.instance.enemy.GetComponent<Enemy>().enemyMaxLife.ToString();
    }

    public void UpdateLife()
    {     
        StartCoroutine(ChangeToLife(CombatManager.instance.enemy.GetComponent<Enemy>().EnemyCurrentLife));     
    }

    private IEnumerator ChangeToLife(int life)
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
}
