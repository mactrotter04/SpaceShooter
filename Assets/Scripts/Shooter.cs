using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float progectileSpeed;
    [SerializeField] float progectileLifeTime = 5f;
    [SerializeField] float fireingRate = 0.2f;

    public bool isFireing;

    Coroutine fireingCourutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFireing && fireingCourutine == null)
        {
            fireingCourutine = StartCoroutine(FireContiniously());
        }
        else if (!isFireing && fireingCourutine !=null)
        {
            StopCoroutine(fireingCourutine);
            fireingCourutine = null;
        }
    }

    IEnumerator FireContiniously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();

            if(rb2d != null)
            {
                rb2d.linearVelocity = transform.up * progectileSpeed;
            }

            Destroy(instance, progectileLifeTime);
            yield return new WaitForSeconds(fireingRate);
        }
    }
}
