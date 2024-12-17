using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallTrigger : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneController.instance.ChangeScene(sceneName, 0);
    }
}
