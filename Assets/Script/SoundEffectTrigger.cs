using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEffectTrigger : MonoBehaviour
{
    public static SoundEffectTrigger Instance;

    public AudioClip bgm;
    public float bgmVolume;
    public bool isBGMContinues;
    public bool newBGM;

    private AudioSource track01, track02;
    private bool isBGMPlay;

    private void Awake()
    {
        if (newBGM)
        {
            if(Instance != null)
            {
                Destroy(Instance);
                Destroy(Instance.gameObject);
            }
            Instance = null;
        }
        if (Instance == null)
        {
            Instance = this;
            if (isBGMContinues)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        isBGMPlay = true;
        //track01.loop = false;
        //track02.loop = false;
        SwapTrack(bgm);
        track01.loop = true;
    }

    public void SwapTrack(AudioClip newClip)
    {
        
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));

        isBGMPlay = !isBGMPlay;

    }

    public void ReturnToDefault()
    {
        SwapTrack(bgm);
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElapsed = 0;

        if (isBGMPlay)
        {
            track01.clip = newClip;
            track01.Play();

            while(timeElapsed < timeToFade)
            {
                track01.volume = Mathf.Lerp(0, bgmVolume, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
            }

            track02.Stop();
            yield return null;
        }
        else
        {
            track02.clip = newClip;
            track02.Play();


            while (timeElapsed < timeToFade)
            {
                track02.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                track01.volume = Mathf.Lerp(bgmVolume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
            }

            track01.Stop();
            yield return null;
        }
    }

    public void ChangeSceneFromSFX(string sceneName, int delay)
    {
        SceneController.instance.ChangeScene(sceneName, delay);
    }

}
