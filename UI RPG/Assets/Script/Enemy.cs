using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Charachter 
{
    public enum EnemyType
    {
        Duck,
        Slime,
        Skeleton
    }
    
    [SerializeField] private float minDamage, maxDamage;
    [SerializeField] private EnemyType enemyType;

    private GameObject currentVisualInstance;

    public float GetDamage()
    {
        switch (enemyType)
        {
            case EnemyType.Duck:
                return Random.Range(3f, 8f);

            case EnemyType.Slime:
                return Random.Range(2f, 6f);

            case EnemyType.Skeleton:
                return Random.Range(4f, 9f);
            default:
                return Random.Range(minDamage, maxDamage);
        }
        
        //return Random.Range(minDamage, maxDamage);
    }
    
    public override void Attack(Charachter toHit) // override
    {
        if (animator != null)
            animator.SetTrigger("attack");
        float damage = GetDamage(); // Random damage
        Shield shield = FindObjectOfType<Shield>();
        if (shield != null)
        {
            damage = shield.BlockDamage(damage);
            shield.Charge(damage);
        }
        toHit.TakeDamage(damage); // Hit Player with random damage
    }
    
    public EnemyType Type
    {
        get { return enemyType; }
        set { enemyType =  value; }
    }

    public void SetupEnemy(GameObject prefab)
    {
        if (currentVisualInstance != null)
            Destroy(currentVisualInstance);
        
        currentVisualInstance = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        animator = currentVisualInstance.GetComponent<Animator>();
        
        animator.ResetTrigger("death");
        animator.ResetTrigger("hit");
        animator.ResetTrigger("attack");
        
        if (prefab.name.Contains("Duck"))
            enemyType = EnemyType.Duck;
        else if (prefab.name.Contains("Slime"))
            enemyType = EnemyType.Slime;
        else if (prefab.name.Contains("Skeleton"))
            enemyType = EnemyType.Skeleton;
    }

    public void PlayDeathAnimation()
    {
        if (animator != null)
            animator.SetTrigger("death");
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
