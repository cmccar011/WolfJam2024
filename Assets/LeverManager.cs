using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{

    public bool beenHit;

    // Start is called before the first frame update
    void Start()
    {
        beenHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beenHit)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit!");
        if (col.gameObject.CompareTag("Projectile"))
        {
            beenHit = true;
            Debug.Log("Kaboom");
        }
    }


}
