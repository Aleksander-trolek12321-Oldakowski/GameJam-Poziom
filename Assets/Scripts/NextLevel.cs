using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject WinSound;
    bool help = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && help == false)
        {
            WinSound.SetActive(true);
            StartCoroutine(ChangeLevel());
            help = true;
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level_2");
    }
}
