using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Charachter enemy;

    [SerializeField] private TMP_Text playerName, playerHP, playerWeapon, enemyName, enemyHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("player: " + player.CharName);
        //player.TakeDamage(3);
        //enemy.TakeDamage(5);
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.CharName;
        playerHP.text = "HP: " + player.health.ToString("F1");
        enemyHP.text = "HP: " + enemy.health.ToString("F1");
        playerWeapon.text = player.ActiveWeaponName;
    }

    public void SwitchWeapon()
    {
        player.SwitchWeapon();
        UpdateUI();
    }

    public void AttackButton()
    {
        player.Attack(enemy);
        enemy.Attack(player);
        UpdateUI();
    }
}
