using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 2f;

    [SerializeField] AudioSource audioFade;

    void Start()
    {
        StartCoroutine(FadeFromBlack());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndSwitchScene(sceneName));
    }

    IEnumerator FadeFromBlack()
    {
        float t = fadeDuration;
        Color c = fadeImage.color;
        while (t > 0)
        {
            t -= Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

    IEnumerator FadeAndSwitchScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);

        float t = 0f;
        Color c = fadeImage.color;
        float startVolume = (audioFade != null) ? audioFade.volume : 1f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float progress = t / fadeDuration;

            c.a = Mathf.Clamp01(progress);
            fadeImage.color = c;

            if (audioFade != null)
            {
                audioFade.volume = Mathf.Lerp(startVolume, 0f, progress);
            }
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }
}
