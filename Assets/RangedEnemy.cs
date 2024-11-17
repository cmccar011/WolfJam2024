using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform target;
    public float _speed = 3f;
    public float _rotationSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public float _distanceToShoot = 5f;
    public float _distanceToStop = 3f;

    public float _fireRate;
    private float _timeToFire;

    public Transform _firingPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (Vector2.Distance(target.position, transform.position) <= _distanceToStop)
        {
            rb.velocity = Vector2.zero;
        }

        else
        {
            rb.velocity = transform.up * _speed;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 _targetDirection = target.position;
        _targetDirection.z = 0f;
        _targetDirection.x = _targetDirection.x - transform.position.x;
        _targetDirection.y = _targetDirection.y - transform.position.y;
        Quaternion _angle = Quaternion.LookRotation(Vector3.forward, _targetDirection);

        transform.rotation = Quaternion.Lerp(transform.rotation, _angle, _rotationSpeed * Time.deltaTime);
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
        else if(other.gameObject.CompareTag("Bullet"))
        {
                Destroy(other.gameObject);
                Destroy(gameObject);
        }
        
    }
}