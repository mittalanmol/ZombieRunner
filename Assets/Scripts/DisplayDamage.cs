using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float imapctTime = 0.3f;
    void Start()
    {
        impactCanvas.enabled = false; // when we start the game it is disabled
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(imapctTime);
        impactCanvas.enabled = false;
    }
}
