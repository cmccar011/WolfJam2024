using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 1000f;

    public Rigidbody2D playerBody;

    public Vector2 mousePosition; 

    public Vector2 moveDirection;

    public Camera sceneCamera;

    Quaternion target = Quaternion.Euler(0, 0, 0);

    public float aimAngle;

    public GameObject rotateTracker;

    //bool warpRes;

    public knifeScript scriptKnife;

    public EffectsFromRuinStones ruinStoneScript;

    public bool canThrow;

    public float throwDelay = 1f;

    GameObject thrown;

    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        //warpRes = true;
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
        
        if (canThrow && ruinStoneScript.resonance)
        {
            thrown = scriptKnife.KnifeThrow(); 
            StartCoroutine(DelayThrow(throwDelay));
        }
        else if (!canThrow)
        {
            if (thrown != null)
            {
                scriptKnife.teleport(thrown);
                //StartCoroutine(DelayThrow(throwDelay));
            }
        }
    }

        IEnumerator DelayThrow(float x)
    {   
        canThrow = false;
        yield return new WaitForSeconds(x);
        canThrow = true; 
        Debug.Log("Running...");
    }

       /* private void OnCollisionEnter2D(Collision other)
        {
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(gameObject);
            }
        }
     */
}
