using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Только это пространство имен для управления сценами
using UnityEngine.UI;

public class pismo : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;
    [SerializeField]
    private Text _noteText;
    public GameObject MessagePanel;
    public bool Action = false;

    private AudioSource source;
    public AudioClip pagesclip;

    private string[] messages = { "Разве не бред? Ты бы поверил в это? Он еще говорил о каких-то рунах…\n\nС любовью, Биржан.\nДалее кнопка « T » ", "Дорогой друг,\n\nС глубоким сожалением сообщаю, что наш друг Жангирхан был унесен в недра Алтайских лесов. Это таинственное место, где многие поколения искателей исчезли, стало его последним приключением. \nНе знаю стоит ли говорить об этом… ", "Но недавно нашелся свидетель, который рассказал нам немного о жутком существе, называемом Жестырнак. Это злой дух, который убивает своим криком. Мы не можем утверждать с уверенностью, что это был именно он, но существует вероятность. " }; // Массив текстов
    private int currentMessageIndex = 0; // Индекс текущего текста

    void Start()
    {
        MessagePanel.SetActive(false);
        _noteImage.enabled = false;
        _noteText.enabled = false;
        _noteText.text = messages[currentMessageIndex];
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action)
        {
            _noteImage.enabled = true;
            _noteText.enabled = true;
            MessagePanel.SetActive(false);

            currentMessageIndex = (currentMessageIndex + 1) % messages.Length;
            _noteText.text = messages[currentMessageIndex];
            source.Stop();
            source.PlayOneShot(pagesclip);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("home");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(false);
            Action = false;
            _noteImage.enabled = false;
            _noteText.enabled = false;
        }
    }
}
