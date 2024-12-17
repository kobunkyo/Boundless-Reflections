using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialogue;
    private bool dialoguePopUp = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialoguePopUp)
        {
            dialogue.SetActive(true);
            PlayerMovement.Instance.isEvent = true;
            dialoguePopUp = false;
        }
    }
}
