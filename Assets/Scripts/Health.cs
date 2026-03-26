using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }


    void TakeDamage(int damage)
    {
        health -= damage; //health = health - damage;

        if(health <- 0)
        {
            Destroy(gameObject);
        }
    }
}
