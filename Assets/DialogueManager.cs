using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //Assets that are talking to each other
    public GameObject person1;
    public GameObject person2;

    //Dialogues
    public string[] dialogue1;
    public string[] dialogue2;

    //Trigger boxes and scene management
    public BoxCollider triggerDialogue;
    public Text text1;
    public Image image1;

    public Text text2;
    public Image image2;

    bool isDialogueActive;
    int dialoguePos1;
    int dialoguePos2;

    // Start is called before the first frame update
    void Start()
    {
        triggerDialogue = gameObject.GetComponent<BoxCollider>();
        isDialogueActive = false;
        dialoguePos1 = 0;
        dialoguePos2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDialogueActive)
        {
            image1.enabled = false;
            image2.enabled = false;
            text1.enabled = false;
            text2.enabled = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                manageDialogue();
            }
        }
    }

    public void manageDialogue()
    {
        if (dialoguePos1 == dialoguePos2)
        {
            image1.enabled = true;
            text1.enabled = true;
            image2.enabled = false;
            text2.enabled = false;
            text1.text = dialogue1[dialoguePos1];
            dialoguePos1++;

        }
        else
        {
            image2.enabled = true;
            text2.enabled = true;
            image1.enabled = false;
            text1.enabled = false;
            text2.text = dialogue2[dialoguePos2];
            dialoguePos2++;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        isDialogueActive = true;
        Debug.Log("here!");
        image1.gameObject.Transform = new Vector3(person1.transform.position.x, person1.transform.position.y + 1, 0);
        image2.gameObject.Transform = new Vector3(person2.transform.position.x, person2.transform.position.y + 1, 0);
    }
}
