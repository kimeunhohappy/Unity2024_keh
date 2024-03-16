using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class SampleTextManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI npcNameText;
    public Image npcIcon;

    public string iconID;

    public Queue<string> stringQueue;
    public float typeSpeed;

    public GameObject TextParent;
    private void Awake()
    {
        stringQueue = new Queue<string>();
    }

    private void Start()
    {
//        npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public void StartText(SampleText[] sampleTexts)
    {
        TextParent.SetActive(true);
        npcNameText.text = sampleTexts[0].npcName;
        textComponent.text = sampleTexts[0].sentences[0];
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{sampleTexts[0].ImageName}");
        SampleText sampleText = sampleTexts[0];

        foreach (string sentence in sampleText.sentences)
        {
            stringQueue.Enqueue(sentence);
        }

    }

    public void DisplayNextSentence()
    {
        Debug.Log("다음 StringQueue 내용 넣기");

        if (stringQueue.Count == 0)
        {
            TextParent.SetActive(false);

            return;
        }
        string sentence = stringQueue.Dequeue();
        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        textComponent.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textComponent.text += letter;

            yield return new WaitForSeconds(typeSpeed);
        }
    }

}
