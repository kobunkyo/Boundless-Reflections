using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerMovement.Instance != null)
        {
            if (!PlayerMovement.Instance.isEvent)
            {
                if(Input.GetAxisRaw("Horizontal") != 0)
                {
                    sfx.enabled = true;
                }
                else
                {
                    sfx.enabled = false;
                }
            }
            else
            {
                sfx.enabled = false;
            }
        }
    }
}
