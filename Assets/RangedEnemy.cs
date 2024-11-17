using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public GameObject orph;

    public Transform target;
    public float _speed = 3f;
    public float _rotationSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public float _distanceToShoot = 10f;
    public float _distanceToStop = 5f;

    public float _fireRate;
    private float _timeToFire;

    public Transform _firingPoint;

    //Patrol path stuff
    public Transform[] locations;
    public int pastLocation;
    public int goal;
    bool detected;
    int direction;
    bool talking;

    UnityEngine.AI.NavMeshAgent _agent;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        talking = false;
        detected = false;
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        pastLocation = 0;
        goal = 1;
        direction = 1;
        talking = false;
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(target.position, transform.position) <= _distanceToStop)
        {
            Debug.Log("Bang");
            Shoot();
        }

    }

    private void Shoot()
    {
        if (_timeToFire <= 0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, _firingPoint.position, _firingPoint.rotation);
            
            Debug.Log("Shoot");
            _timeToFire = _fireRate;
        }
        else
        {
            _timeToFire -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Vector2.Distance(gameObject.transform.position, orph.transform.position) < 5f)
        {
            detected = true;
        }

        if (!talking)
        {
            if (detected)
            {
                target = orph.transform;
            }
            else
            {
                target = locations[goal];
                if (Vector2.Distance(gameObject.transform.position, locations[goal].position) < 2)
                {
                    //This here allows swapping directions
                    Debug.Log("reached");
                    if (goal == locations.Length - 1)
                    {
                        Debug.Log("Swapped");
                        direction = -1;
                    }
                    else if (goal == 0)
                    {
                        direction = 1;
                    }
                    goal += direction;
                }
            }
            _agent.SetDestination(target.position);

        }
        else
        {
            _agent.SetDestination(gameObject.transform.position); //Hopefully this causes it to stand still?
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 _targetDirection = target.position;
        _targetDirection.z = 0f;
        _targetDirection.x = _targetDirection.x - transform.position.x;
        _targetDirection.y = _targetDirection.y - transform.position.y;
        Quaternion _angle = Quaternion.LookRotation(Vector3.forward, _targetDirection);

       // transform.rotation = Quaternion.Lerp(transform.rotation, _angle, _rotationSpeed * Time.deltaTime);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            target = null;
        }
        else if(other.gameObject.CompareTag("Projectile"))
        {
                Destroy(other.gameObject);
                Destroy(gameObject);
        }
        
    }
}