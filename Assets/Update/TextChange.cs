using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChange : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] Tips = new string[9];
    int UpdateWhileNumber = 0;
    float TimedotdeltatimeWhileSavingNumber = 0;
    public float ChangeTimeing;

    void Update()
    {
        if(TimedotdeltatimeWhileSavingNumber >= ChangeTimeing)
        {
            if (UpdateWhileNumber >= Tips.Length)
            {
                UpdateWhileNumber = 0;
            }

            text.text = "Tip!\n" + Tips[UpdateWhileNumber];
            UpdateWhileNumber += 1;
            TimedotdeltatimeWhileSavingNumber = 0;
        }
        else
        {
            TimedotdeltatimeWhileSavingNumber += Time.deltaTime;
        }
    }
}