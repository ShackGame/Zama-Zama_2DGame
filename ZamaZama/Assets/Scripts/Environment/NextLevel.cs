using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NextLevel : MonoBehaviour
{
    public string nextSceneAddress;

    public Animator transition;

    public float transtionTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transtionTime);

        Addressables.LoadSceneAsync(nextSceneAddress);
    }
}
