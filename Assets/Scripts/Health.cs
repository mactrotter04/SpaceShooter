using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    [SerializeField] float deathdelay = 2f;
 
    Audiomanager Audiomanager;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    Animator animator;

    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        Audiomanager = FindAnyObjectByType<Audiomanager>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            Audiomanager.PlayDamageSFX();
        }
    }


    void TakeDamage(int damage)
    {
        health -= damage; //health = health - damage;

        if(health <- 0)
        {
            Death();
        }
    }

    void Death()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }

        GetComponent<Collider2D>().enabled = false; 
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        if (animator != null)
        {
            animator.SetTrigger("Death");
        }
      
        Destroy(gameObject, deathdelay);
    }


}
