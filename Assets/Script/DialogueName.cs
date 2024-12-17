using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueName : MonoBehaviour
{
    public static DialogueName Instance;
    public string[] names;
    public TextMeshProUGUI nameComponent;

    private void Awake()
    {
        Instance = this;
    }

    private int index;
    void Start()
    {
        index = 0;
        nameComponent.text = names[index];
    }

    public void NextLine()
    {
        if (index < names.Length - 1)
        {
            index++;
            nameComponent.text = names[index];
        }
        else
        {
            gameObject.SetActive(false);
            if (PlayerMovement.Instance != null) { 
                PlayerMovement.Instance.isEvent = false;
            }
        }
    }
}
