using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    public string scene;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeScene(string sceneName, int delay)
    {
        StartCoroutine(LoadLevel(sceneName, delay));
    }

    IEnumerator LoadLevel(string sceneName, int delay)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneName);
        transitionAnim.SetTrigger("Start");
    }
}
