using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFADE : MonoBehaviour
{
    //여러스크립트에 동시에 쓴다면 불값은 다른스크립트에서 조정해야 안겹침
    public bool mFaded = true; 
    public float duration = 0.4f;

    public void Fadem()
    {
        CanvasGroup canvGroup = this.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        mFaded = !mFaded;



    }
    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;
        while(counter<duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start,end, counter/duration);
            yield return null;
        }
    }

}
