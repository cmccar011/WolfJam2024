using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 1000f;

    public Rigidbody2D playerBody;

    public Vector2 mousePosition; 

    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        //Chane to velocity?
        playerBody.velocity = (moveDirection * moveSpeed * Time.deltaTime);
        //limitVelocity(maxVelocity);

    }

        public void GetMove(InputAction.CallbackContext context)
    {
        moveDirection = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y); 
    }

}
