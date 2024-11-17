using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    public GameObject knife;

    public GameObject spawnPoint;   
    public Transform playerPosition;     

    public Transform rotationTracker;

    public float throwForce = 200f;

    public float timeToDestroy = .28f;  

    public void KnifeThrow()
    {
        GameObject thrownKnife = Instantiate(knife, spawnPoint.transform.position, rotationTracker.rotation);
        thrownKnife.GetComponent<Rigidbody2D>().AddForce(spawnPoint.transform.up * throwForce, ForceMode2D.Force); 
        DeleteThrown(thrownKnife);
    }

    public void DeleteThrown(GameObject thrown)
    {
        Destroy(thrown.gameObject, .50f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
