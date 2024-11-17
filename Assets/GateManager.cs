using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateManager : MonoBehaviour
{


    //The two levers that control it
    public GameObject lever1;
    public GameObject lever2;

    //Managing the actual gate
    bool nowRaised;

    // Start is called before the first frame update
    void Start()
    {
        nowRaised = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever1.GetComponent<LeverManager>().beenHit && lever2.GetComponent<LeverManager>().beenHit)
        {
            //raise the gate
            nowRaised = true;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && nowRaised)
        {
            //Move to the final scene
            Debug.Log("End");
            SceneManager.LoadScene(2);
        }
    }
}
