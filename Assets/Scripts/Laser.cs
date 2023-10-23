using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 1.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.name == "Evil_Moon")
        {
            Moon moon = collision.GetComponent<Moon>();
            if (moon.been_hit == false)
            {
                moon.been_hit = true;
            }
        }
        Destroy(gameObject);
    }
}
