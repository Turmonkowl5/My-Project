using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;    
    private float yRange = 24;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {

        int randomIndex = Random.Range(0, enemy.Length);        
        float randomY = Random.Range(-yRange, yRange);
        Vector3 randomPos = new Vector3(-55, randomY, 7);
        Instantiate(enemy[randomIndex], randomPos, enemy[randomIndex].transform.rotation);
    }
}
