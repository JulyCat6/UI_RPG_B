using UnityEngine;

public abstract class Charachter : MonoBehaviour
{
    // abstrast = наследование/mantojums
    // No Character script mantoja/наследуются Player script un Enemy script 
    // Character = base script
    public float health;
    [SerializeField] private string charName; // private bet to var redzēt Unity, pateicoties SerializeField
    [SerializeField] protected Animator animator;
    // protected - class + mantotaji

    public string CharName
    {
        get { return charName; } // getter = способ получить значение переменной. // Encapsulacija. Citas klases var izlasit name, bet nevar to samainit
        
    }
    public void SetEnemyName(string newName)
    {
        charName = newName;
    }

    public abstract void Attack(Charachter toHit); // katram character vajadzetu but attack

    public void TakeDamage(float damage) // atniem health
    {
        health = health-damage;
        animator.SetTrigger("hit");
        Debug.Log(charName + "got hit for" + damage + "damage!" + "Current health: " + health);
    }

    public void TakeDamage(Weapon weapon) // overload
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
