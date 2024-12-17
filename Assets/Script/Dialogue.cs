using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public AudioClip triggerSFX;
    public bool isTriggerScene;
    public bool isChangeOnly;
    public int delay;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
                if(DialogueName.Instance != null)
                {
                    DialogueName.Instance.NextLine();
                }
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty ;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if (isTriggerScene)
            {
                SoundEffectTrigger.Instance.SwapTrack(triggerSFX);
                SoundEffectTrigger.Instance.ChangeSceneFromSFX(SceneController.instance.scene, delay);
            }
            if (isChangeOnly)
            {
                SceneController.instance.ChangeScene(SceneController.instance.scene, delay);
            }
            if(!isTriggerScene && !isChangeOnly)
            {
                if(ItemSelected.instance != null)
                    ItemSelected.instance.isActive = true;
            }
        }
    }
}
