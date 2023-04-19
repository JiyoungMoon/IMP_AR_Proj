using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02Effect : MonoBehaviour
{
    public GameObject splitObject;
    public float explosionForce;
    public float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log("touched");

            List<Rigidbody> rb = new List<Rigidbody>();
            int ran = Random.Range(6, 11);
            for(int i = 0; i < ran; i++)
            {
                rb.Add(Instantiate(splitObject, transform.position + Random.insideUnitSphere * 2f, Quaternion.identity).GetComponent<Rigidbody>());
            }
            Vector3 pos = (transform.position - GetComponent<Rigidbody>().velocity.normalized * 2.5f);


            foreach (Rigidbody rigidbody in rb) 
            {
                rigidbody.AddForce((rigidbody.transform.position - pos).normalized * explosionForce);
            }
            Destroy(gameObject);
        }
    }

}
