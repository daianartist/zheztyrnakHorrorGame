using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private string[] messages = { "Сообщение 1", "Сообщение 2", "Сообщение 3" }; // Массив текстов
    private int currentMessageIndex = 0; // Индекс текущего текста

    void Start()
    {
        MessagePanel.SetActive(false);
        _noteImage.enabled = false;
        _noteText.enabled = false;
        _noteText.text = messages[currentMessageIndex];
        source = GetComponent<AudioSource>();
        // Инициализация текста первым сообщением
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action)
        {
            _noteImage.enabled = true;
            _noteText.enabled = true;
            MessagePanel.SetActive(false);

            // Переключение текста
            currentMessageIndex = (currentMessageIndex + 1) % messages.Length;
            _noteText.text = messages[currentMessageIndex];
            source.Stop();
            source.PlayOneShot(pagesclip);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Загрузка новой сцены по имени
            SceneManager.LoadScene("home");
            // Или по индексу
            // SceneManager.LoadScene(1);
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
