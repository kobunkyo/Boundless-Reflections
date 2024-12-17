using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Start : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneController.instance.ChangeScene(SceneController.instance.scene, 0);
        }
    }
}
