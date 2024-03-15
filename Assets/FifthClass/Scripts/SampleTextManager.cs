using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SampleTextManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI npcNameText;
    public Image npcIcon;

    public string iconID;

    public Queue<string> stringQueue;

    private void Start()
    {
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public void StartText(SampleText[] sampleTexts)
    {
        npcNameText.text = sampleTexts[0].npcName;
        textComponent.text = sampleTexts[0].sentences[0];

        SampleText sampleText = sampleTexts[0];

        //foreach(string sentence in sampleText.sentences)
        //{
        //    stringQueue.Enqueue(sentence);
        //}

    }

    public void DisplayNextSentence()
    {
        Debug.Log("다음 StringQueue 내용 넣기");
    }

}
