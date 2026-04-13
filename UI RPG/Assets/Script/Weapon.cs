using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //[SerializeField] private float minDamage, maxDamage;
    public string weaponName;

    //public virtual float GetDamage()
    //{
        //return Random.Range(minDamage, maxDamage);
    //}

    public virtual void AttackSound()
    {
        Debug.Log("Weapon Sound");
    }
    
    public abstract float GetDamage();
    
    //public virtual void HealSound()
}
