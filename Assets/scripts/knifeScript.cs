using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    public GameObject knife;

    public GameObject spawnPoint;   

    public GameObject player;
    public Transform playerPosition;     

    public Transform rotationTracker;

    public float throwForce = 1000f;

    public float timeToDestroy = .28f;  

    public void KnifeThrow()
    {
        GameObject thrownKnife = Instantiate(knife, spawnPoint.transform.position, rotationTracker.rotation);
        thrownKnife.GetComponent<Rigidbody2D>().AddForce(spawnPoint.transform.up * throwForce, ForceMode2D.Force); 
        DeleteThrown(thrownKnife);
    }

    public void warpKnifeThrow()
    {
        GameObject thrownKnife = Instantiate(knife, spawnPoint.transform.position, rotationTracker.rotation);
        thrownKnife.GetComponent<Rigidbody2D>().AddForce(spawnPoint.transform.up * throwForce, ForceMode2D.Force);
        WarpThenDelete(thrownKnife);
    }

    public void DeleteThrown(GameObject thrown)
    {
        Destroy(thrown.gameObject, .50f);
    }

    public void WarpThenDelete(GameObject thrown)
    {
        Delay(.48f);
        player.transform.position = thrown.transform.position;
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

    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

    IEnumerator Delay(float x)
    {   
        yield return new WaitForSeconds(x); 
    }
    
}
