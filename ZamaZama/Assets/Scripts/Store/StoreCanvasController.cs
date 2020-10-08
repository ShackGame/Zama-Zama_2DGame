using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject openstoreCollider;
    public void Openstore()
    {
        StartCoroutine(WaitBeforeOpeningStore());
    }
    IEnumerator WaitBeforeOpeningStore()
    {
        yield return new WaitForSeconds(3f);
        openstoreCollider.SetActive(true);
    }

    public void GrandReward()
    {
        GameManager.instance.Score += 1500f;
    }
}
