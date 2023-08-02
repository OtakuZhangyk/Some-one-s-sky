using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    
    public Image fadePanel;
    public float fadeDuration = 2.0f;


    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadRoutine(sceneName));
    }

    IEnumerator FadeAndLoadRoutine(string sceneName)
    {
        // Fade to black
        yield return Fade(Color.clear, Color.black);

        // Load the scene
        SceneManager.LoadScene(sceneName);

        // Fade to clear
        yield return Fade(Color.black, Color.clear);
    }

    IEnumerator Fade(Color fromColor, Color toColor)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = Color.Lerp(fromColor, toColor, normalizedTime);
            yield return null;
        }

        fadePanel.color = toColor;
    }

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
