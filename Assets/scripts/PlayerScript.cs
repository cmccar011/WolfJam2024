using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 1500f;

    public Rigidbody2D playerBody;

    public Vector2 mousePosition; 

    public Vector2 moveDirection;

    public Camera sceneCamera;

    Quaternion target = Quaternion.Euler(0, 0, 0);

    public float aimAngle;

    public GameObject rotateTracker;

    public knifeScript scriptKnife;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - playerBody.position; 
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 270f;
        target = Quaternion.Euler(0, 0, aimAngle);
        rotateTracker.transform.rotation = target;  

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

        public void Fire(InputAction.CallbackContext context)
    {
        scriptKnife.KnifeThrow(); 
    }

}
