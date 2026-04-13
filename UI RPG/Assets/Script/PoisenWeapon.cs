using UnityEngine;

public class PoisenWeapon : Weapon
{
    [SerializeField] private float minDamage,  maxDamage;
    
    public float poisonDamage;
    public int poisonCount;
    
    public override float GetDamage()
    {
        float damage = Random.Range(minDamage, maxDamage);
        
        if (poisonCount > 0)
        {
            poisonCount--;
            damage += poisonDamage;
        }
        return damage;
    }
}
