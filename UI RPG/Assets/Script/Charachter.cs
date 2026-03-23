using UnityEngine;

public abstract class Charachter : MonoBehaviour
{
    public float health;
    [SerializeField] private string charName;

    public string CharName
    {
        get { return charName; }
        
    }

    public abstract void Attack(Charachter toHit);

    public void TakeDamage(float damage)
    {
        health = health-damage;
        Debug.Log(charName + "got hit for" + damage + "damage!" + "Current health: " + health);
    }

    public void TakeDamage(Weapon weapon)
    {
        float damage = weapon.GetDamage();
        TakeDamage(damage);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
