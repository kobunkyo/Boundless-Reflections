using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelected : MonoBehaviour
{
    public static ItemSelected instance;
    public GameObject items;
    private SpriteRenderer item;
    private Color originalColor;
    private Color highlightColor = Color.green;
    public bool isActive = false;
    public GameObject dialogue;
    public Animator itemAnimation;

    private bool readyToClick = false;
    private bool isHover = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        item = GetComponent<SpriteRenderer>();
        if(item != null)
        {
            originalColor = item.color;
        }
    }

    private void Update()
    {
        if (isHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (readyToClick)
                {
                    items.SetActive(true);
                    itemAnimation.SetTrigger("Start");
                    readyToClick = false;
                }
            }
        }
        else
        {
            if (!readyToClick && items.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(ItemBannish());
                    if(dialogue != null)
                    {
                        dialogue.SetActive(true);
                        StopCoroutine(ItemBannish());
                    }

                }
            }
        }
    }

    private void OnMouseEnter()
    {
        isHover = true;
        if (isActive) { 
            item.color = highlightColor;
            if(items != null)
            {
                readyToClick = true;
            }
        }
    }

    private void OnMouseExit()
    {
        isHover = false;
        if (isActive) { 
            item.color = originalColor;
        }
    }

    IEnumerator ItemBannish()
    {
        itemAnimation.SetTrigger("End");
        yield return new WaitForSeconds(1);
        items.SetActive(false);
        Destroy(gameObject);
    }
    
}
