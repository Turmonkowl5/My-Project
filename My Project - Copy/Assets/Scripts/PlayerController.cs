using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float topBoundry = 28;
    private float sideBoundry = 50;
    public GameObject pewpew;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip pew;
    [SerializeField] AudioClip expoSound;
    private AudioSource playerAudio;
    [SerializeField] GameObject shipMesh;
    [SerializeField] GameObject gameMusic;
    [SerializeField] float timeToShoot;
    [SerializeField] float timer;

    

    private float lastYVal;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        timer = Time.time;
        lastYVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        ConstrainPlayer();
        MovePlayer();
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(timer >= timeToShoot)
            {
                Shoot();
                timer = 0;
            }

            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, 60);
            ChangeFieldOfView(25);
        }
        else
        {
            Camera.main.transform.position = new Vector3(0,0,60);
            ChangeFieldOfView(60);
        }
    }



    void UpdateTimer()
    {
        timer += Time.deltaTime;

    }
    void ChangeFieldOfView(int fieldOfView)
    {
       Camera.main.fieldOfView = fieldOfView;
       

    }

    //Move Player based on arrow keys
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
        
    }



    //Constrain Player Movement
    void ConstrainPlayer() 
    {
        if (transform.position.y > topBoundry)
        {
            transform.position = new Vector3(transform.position.x, topBoundry, transform.position.z);
        }
        if (transform.position.y < -topBoundry)
        {
            transform.position = new Vector3(transform.position.x, -topBoundry, transform.position.z);
        }
        if (transform.position.x < -sideBoundry)
        {
            transform.position = new Vector3(-sideBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.x > sideBoundry - 8)
        {
            transform.position = new Vector3(sideBoundry -8, transform.position.y, transform.position.z);
        }
    }


    void Shoot()
    {
        playerAudio.PlayOneShot(pew, .7f);
        Instantiate(pewpew, transform.position, pewpew.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            Die();
            Destroy(other.gameObject);
            
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }

    void Die()
    {
        gameMusic.GetComponent<AudioSource>().Stop();
        ExplosionSound();
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(shipMesh);
        Destroy(gameObject, 3f);
        
        
    }

    void ExplosionSound()
    {
        playerAudio.PlayOneShot(expoSound, 1);
    }
}
