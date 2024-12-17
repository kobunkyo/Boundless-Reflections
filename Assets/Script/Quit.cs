using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private float delay = 5f;
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }
    }
}
