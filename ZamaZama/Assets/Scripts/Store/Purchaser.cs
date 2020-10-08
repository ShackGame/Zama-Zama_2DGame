using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchaser : MonoBehaviour
{
    public TMP_Text transactionTxt;

    private void Start()
    {
        transactionTxt.text = "";
    }
    public void PurchaseCompleteGrantcredits(float coins)
    {
        //Give player coins
        transactionTxt.text = "Transaction successful!";
        GameManager.instance.Score += coins;

        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        transactionTxt.text = "";
    }

    public void PurchaseFailedGrantcredits()
    {
        //Give player coins

        transactionTxt.text = "Transaction Failed!";
    }
}
