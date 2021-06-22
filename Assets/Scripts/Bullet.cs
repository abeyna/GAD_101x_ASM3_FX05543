using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
    }

    private void Update()
    {
        if (transform.position.y > 6)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Block"))
        {
            collision.SendMessageUpwards("OnDamaged", bulletDamage);
        }

        if(!collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
