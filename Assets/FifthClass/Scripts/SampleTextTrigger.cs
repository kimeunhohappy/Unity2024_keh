using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTextTrigger : MonoBehaviour
{
    public SampleText[] sampleText;

    private void Start()
    {
        TriggerText(sampleText);
    }

    public void TriggerText(SampleText[] sampleTexts)
    {
        FindObjectOfType<SampleTextManager>().StartText(sampleTexts);
    }

}
