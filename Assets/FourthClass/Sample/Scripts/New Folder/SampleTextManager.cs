using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleTextManager : MonoBehaviour
{
    public TextMeshProUGUI textCompoent;
    public TextMeshProUGUI NpcNametext;
    public Image npcicon;

    public Queue<string> stringQueue = new Queue<string>();

    public string iconID;
    private void Start()
    {
        npcicon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public void Startext(Sampletext[] sampletexts)
    {
        textCompoent.text = sampletexts[0].sentence[0];
        NpcNametext.text = sampletexts[0].title;



    }
}
