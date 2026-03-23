using UnityEngine;

public class Enemy : Charachter
{
    [SerializeField] private float minDamage, maxDamage;
    
    public override void Attack(Charachter toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.TakeDamage(damage);
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
