using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareTrig : MonoBehaviour
{
    public GameObject playerObj, jumpscareCam;
    public Animator monsterAnim;
    public string sceneName;
    public float jumpscareTime = 3.0f;

    public void TriggerJumpscare() // Теперь метод публичный
    {
        playerObj.SetActive(false);
        jumpscareCam.SetActive(true);
        monsterAnim.SetTrigger("jumpscare");
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}
