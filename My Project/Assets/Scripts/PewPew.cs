using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public float pewpewSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        Delete();
    }
        void MoveLeft()
    {

        transform.Translate(Vector3.up * pewpewSpeed * Time.deltaTime);
    }

    void Delete()
    {
        if(transform.position.x < -57)
        {
            Destroy(gameObject);
        }
    }
}
