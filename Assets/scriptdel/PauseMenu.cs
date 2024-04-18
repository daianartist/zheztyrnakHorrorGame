using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false; // Хранение состояния паузы
    public GameObject pauseMenu;          // Ссылка на UI элемент меню паузы

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume(); // Продолжить игру, если она на паузе
            }
            else
            {
                Pause(); // Поставить игру на паузу
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); // Скрыть меню паузы
        Time.timeScale = 1f;        // Возобновить время в игре
        PauseGame = false;          // Отметить, что игра не на паузе
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);  // Показать меню паузы
        Time.timeScale = 0f;         // Остановить время в игре
        PauseGame = true;            // Отметить, что игра на паузе
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;        // Возобновить время в игре перед загрузкой меню
        SceneManager.LoadScene("StartMenu"); // Загрузить начальное меню
    }
}
