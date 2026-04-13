using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Shield shield;

    [SerializeField] private TMP_Text playerName, playerHP, playerWeapon, enemyName, enemyHP, ShieldCome;
    //[SerializeField] private GameObject playerWeapon;
    // UI show player name, player hp,... 
    [SerializeField] private GameObject UIGameOver;
    [SerializeField] private GameObject shieldButton;
    [SerializeField] private GameObject healButton;
    [SerializeField] private Spell heal;
    
    private GameState currentState;
    private int enemyNumber = 1;

    [Header("Enemy Settings")] [SerializeField]
    private GameObject[] enemyPrefabs;
    
    public enum GameState
    {
        GameGo,
        GameOver
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.GameGo;
        UIGameOver.SetActive(false);
        //Debug.Log("player: " + player.CharName);
        //player.TakeDamage(3);
        //enemy.TakeDamage(5);
        //enemy.SetEnemyName("Charlie 1");
        int randomType = Random.Range(0, 3);
        GameObject selectedPrefab = enemyPrefabs[randomType];
        enemy.SetEnemyName(selectedPrefab.name + "1");
        enemy.SetupEnemy(selectedPrefab);
        healButton.SetActive(false);
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.CharName;
        playerHP.text = "HP: " + player.health.ToString("F1"); // F1 viens cipars pec komata
        enemyHP.text = "HP: " + enemy.health.ToString("F1");
        playerWeapon.text = player.ActiveWeaponName;
        ShieldCome.text = "Shield charge: " + shield.charge + "/10";

        if (currentState != GameState.GameGo)
        {
            shieldButton.SetActive(true);
            healButton.SetActive(true);
        }
        else
        {
            shieldButton.SetActive(false);
            healButton.SetActive(false);
        }
        
        shieldButton.SetActive(shield.ready);
        healButton.SetActive(heal.ready);
    }

    public void SwitchWeapon() //switch weapon button
    {
        player.SwitchWeapon();
        UpdateUI();
    }

    public void AttackButton() // ka attack notiek
    {
        if (currentState != GameState.GameGo) return;
        
        player.Attack(enemy);
        EnemyAttack();
        
        shield.EndTurn();
        heal.EndTurn();
        
        UpdateUI();
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (player.health <= 0)
        {
            GameOver();
        }
        
        else if (enemy.health <= 0)
        {
            StartCoroutine(HandleEnemyDeath());
        }

    }

    private void GameOver()
    {
        currentState = GameState.GameOver;
        UIGameOver.SetActive(true);
        
        shieldButton.SetActive(false);
        healButton.SetActive(false);
    }

    public void RestartButton()
    {
        player.health = 30f;
        enemy.health = 25f ;
        UIGameOver.SetActive(false);
        enemyNumber = 1;
        int randomType = Random.Range(0, 3);
        GameObject selectedPrefab = enemyPrefabs[randomType];
        enemy.SetEnemyName(selectedPrefab.name + " 1");
        enemy.SetupEnemy(selectedPrefab);
        shield.RestartShield();
        currentState = GameState.GameGo;
        heal.RestartHeal();
        UpdateUI();
    }
    
    
    private void NewEnemy()
    {
        enemyNumber++;
        enemy.health = 25f;
        int randomType = Random.Range(0, 3);
        GameObject selectedPrefab = enemyPrefabs[randomType];
        enemy.SetupEnemy(selectedPrefab);
        enemy.SetEnemyName(selectedPrefab.name + " " + enemyNumber);
        UpdateUI();
    }

    private void EnemyAttack()
    {
        float damage = enemy.GetDamage();
        damage = shield.BlockDamage(damage);
        player.TakeDamage(damage);
        enemy.Attack(player);
        shield.Charge(damage);
        UpdateUI();
    }

    public void ActivateShield()
    {
        shield.Activate();
        shieldButton.SetActive(false);
        UpdateUI();
    }

    public void HealButton()
    {
        if (!heal.ready) return;
        
        heal.Activate();
        healButton.SetActive(false);
        UpdateUI();
    }

    private IEnumerator HandleEnemyDeath()
    {
        currentState = GameState.GameOver;
        enemy.PlayDeathAnimation();
        yield return new WaitForSeconds(1f);
        
        NewEnemy();
        currentState = GameState.GameGo;
    }
}
