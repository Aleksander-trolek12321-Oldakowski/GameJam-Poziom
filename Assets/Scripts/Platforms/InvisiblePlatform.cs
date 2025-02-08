using System.Collections;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    public int time;
    public GameObject gameObject;
    void Awake()
    {
       StartCoroutine("InvisiblePlatforms"); 
    }

    IEnumerator InvisiblePlatforms()
    {
        while(true)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(time);

            gameObject.SetActive(true);
            yield return new WaitForSeconds(time);

        }
    }

}
