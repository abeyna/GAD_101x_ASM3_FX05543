using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 destination;
    bool isShooting = true;

    [SerializeField] float fireRate = 0.2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;

    public AudioSource shootSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), 0.1f);

            if (isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        shootSFX.Play();
        isShooting = false;
        yield return new WaitForSeconds(fireRate);
        isShooting = true;  
    }
}
