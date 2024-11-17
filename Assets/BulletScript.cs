using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 10f;
    

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 20f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 50f * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            
        }
        //Destroy(gameObject);
    }
}
