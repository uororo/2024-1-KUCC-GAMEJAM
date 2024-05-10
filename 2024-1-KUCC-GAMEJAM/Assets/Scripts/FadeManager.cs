using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public Image fadePanel;
    public TextMeshProUGUI dayText;
    public float fadeDuration = 1.0f;

    private void Awake()
    {
        fadePanel.gameObject.SetActive(true); // 활성화 상태로 초기화
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0); // 시작 시 투명
    }

    public IEnumerator FadeIn()
    {
        float targetAlpha = 1.0f;
        while (fadePanel.color.a < targetAlpha)
        {
            Color newColor = fadePanel.color;
            newColor.a += Time.deltaTime / fadeDuration;
            fadePanel.color = newColor;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float targetAlpha = 0.0f;
        while (fadePanel.color.a > targetAlpha)
        {
            Color newColor = fadePanel.color;
            newColor.a -= Time.deltaTime / fadeDuration;
            fadePanel.color = newColor;
            yield return null;
        }
    }
}
