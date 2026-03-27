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
            GameObject instance = Instantiate(AsteroidToSpawn, RandomSpawnPos, Quaternion.identity);
            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            float randomRotation = Random.Range(0f, 360f);

            if (rb2d != null)
            {
                rb2d.linearVelocity = transform.up * asteroidSpeed;
                transform.Rotate(0f, 0f, randomRotation * Time.deltaTime);
            }

            Destroy(instance, AsteroidLifeTime);
        }
    }
}
