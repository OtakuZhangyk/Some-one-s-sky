using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer Instance { get; private set; }

    public float fadeTime = 2f;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DoDestory()
    {
        FadeOut();
        //Destroy(gameObject);
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        float startVolume = 0f;

        audioSource.volume = startVolume;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

    IEnumerator FadeOutCoroutine()
    {
        while (audioSource.volume > 0.0f)
        {
            audioSource.volume -= Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 1f;
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
