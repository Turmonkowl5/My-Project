using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float xBoundry = 80;
    public ParticleSystem explosion;
    public GameObject enemyName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if(transform.position.x > xBoundry)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PewPew"))
        {
            Destroy(enemyName);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            
        }
    }
}
