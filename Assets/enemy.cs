using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [SerializeField] Transform _target;
    public GameObject orph;
    NavMeshAgent _agent;

    //Patrol path stuff
    public Transform[] locations;
    public int pastLocation;
    public int goal;
    bool detected;
    int direction;

    public bool talking; //I have this here for the dialogue system. Whenever they are talking they are frozen.

    private void Start()
    {
        detected = false;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        pastLocation = 0;
        goal = 1;
        direction = 1;
        talking = false;
    }

    // Update is called once per frame
    private void Update()
    {
       if (Vector2.Distance(gameObject.transform.position, orph.transform.position) < 5f)    {
            detected = true;
        }
        
        if (!talking)
        {
            if (detected)
            {
                _target = orph.transform;
            }
            else
            {
                _target = locations[goal];
                if (Vector2.Distance(gameObject.transform.position, locations[goal].position) < 2)
                {
                    //This here allows swapping directions
                    Debug.Log("reached");
                    if (goal == locations.Length -1)
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
            _agent.SetDestination(_target.position);
            
        }
        else
        {
            _agent.SetDestination(gameObject.transform.position); //Hopefully this causes it to stand still?
        }

    }

}
