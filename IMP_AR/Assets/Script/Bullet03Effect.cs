using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet03Effect : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb == null) continue;
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        Destroy(gameObject);
        Destroy(explosion, 1f);
    }
}
