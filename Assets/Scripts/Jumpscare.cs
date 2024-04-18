using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public GameObject JumpscareCam;
    public GameObject FPSCONTROLLER;
    public AudioSource JumpscareAudio;

    void Start()
    {
        JumpscareCam.SetActive(false);
        FPSCONTROLLER.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger.");
            FPSCONTROLLER.SetActive(false);
            JumpscareCam.SetActive(true);
            JumpscareAudio.Play();
            StartCoroutine(WaitForAudio());
        }
    }

    IEnumerator WaitForAudio()
    {
        // Ожидаем, пока аудио полностью проиграется
        yield return new WaitWhile(() => JumpscareAudio.isPlaying);

        // Переходим на сцену "GameOver"
        SceneManager.LoadScene("GameOver");
    }
}
