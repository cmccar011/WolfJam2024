using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    public GameObject knife;
    public GameObject player;
    public Transform playerPosition;     

    public Transform rotationTracker;

    public float timeToDestroy = .28f;  

    void knifeThrow()
    {
        Quaternion throwAngle = rotationTracker.rotation;
        Vector3 eulerSlashAngle = throwAngle.eulerAngles;
        Vector3 spawnPoint = new Vector3((playerPosition.position.x + 10), playerPosition.position.y, (playerPosition.position.z));
        eulerSlashAngle.z -= 90;
        throwAngle = Quaternion.Euler(eulerSlashAngle);


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
