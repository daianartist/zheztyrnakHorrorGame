using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour
{
    public Text displayText; // Ссылка на текстовый компонент, который нужно активировать
    public string message = "Что же это было? Руны? Мне нужно найти все 5 рун!"; // Текст, который будет отображаться
    public float displayDuration = 4.0f; // Продолжительность отображения текста

    void Start()
    {
        ActivateTextForSeconds(message, displayDuration);
    }

    public void ActivateTextForSeconds(string text, float duration)
    {
        displayText.text = text;
        displayText.gameObject.SetActive(true);
        StartCoroutine(DeactivateAfterSeconds(duration));
    }

    private IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        displayText.gameObject.SetActive(false);
    }
}
