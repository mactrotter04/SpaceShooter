using UnityEngine;
using System.Collections;
public class AsteroidSpawner : MonoBehaviour
{

    [Header("Asteroid Spawns")]
    [SerializeField] GameObject AsteroidToSpawn;
    [SerializeField] float AsteroidSpawnInterval = 1f;
    [SerializeField] float asteroidMaxY;
    [SerializeField] float AsteroidMinY;
    [SerializeField] float asteroidMaxX;
    [SerializeField] float AsteroidMinX;
    [SerializeField] float asteroidSpeed = 1f;
    [SerializeField] float AsteroidLifeTime = 5f;
    [SerializeField] float spinVelocity = 200f;
    [SerializeField] float turnSpeed = 50f;

    float dir;


    void Start()
    {
        StartCoroutine(AsteroidSpawn());
    }
 
    
    IEnumerator AsteroidSpawn()
    {
        while (true)
        {
            float randomY = Random.Range(asteroidMaxY, AsteroidMinY);
            float randomX = Random.Range(asteroidMaxX, AsteroidMinX);
            Vector2 RandomSpawnPos = new Vector2(randomX, randomY);
            dir = Mathf.Sign(Random.Range(-1, 1));
            

            GameObject instance = Instantiate(AsteroidToSpawn, RandomSpawnPos, Quaternion.identity);
            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            

            if (rb2d != null)
            {
                float angle = turnSpeed * dir * Time.deltaTime;
                Vector2 baseVelocity = -transform.up * asteroidSpeed;
                rb2d.linearVelocity = Quaternion.Euler(0, 0 ,angle) * baseVelocity;;
                //rb2d.angularVelocity = Random.Range(-spinVelocity, spinVelocity);
            }

            Destroy(instance, AsteroidLifeTime);

            yield return new WaitForSeconds(AsteroidSpawnInterval);
        }
    }
}
