using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Player Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float progectileSpeed = 10f;
    [SerializeField] float progectileLifeTime = 5f;
    [SerializeField] float baseFireingRate = 0.2f;

    [Header("Enemy Shooting")]
    [SerializeField] bool enemeyFireing;
    [SerializeField] float fireingRateVareance = 1f;
    [SerializeField] float minFireRate = 0.1f;

    [HideInInspector] public bool isFireing;

    Coroutine fireingCourutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemeyFireing)
        {
            isFireing = true;
        }
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

            float timeToNextProjectile = Random.Range(baseFireingRate - fireingRateVareance, baseFireingRate + fireingRateVareance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFireRate, float.MaxValue);


            yield return new WaitForSeconds(baseFireingRate);
        }
    }
}
