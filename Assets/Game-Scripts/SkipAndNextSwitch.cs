using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SkipAndNextSwitch : MonoBehaviour
{
    public StoryViewer Viewer;
    public CanvasGroup Skip, Next;

    private void Start()
    {
        Skip.blocksRaycasts = true;
        Next.blocksRaycasts = false;
    }

    public void skip()
    {
        Skip.blocksRaycasts = false;
        Next.blocksRaycasts = true;
        
        DOTween.Clear();
        Viewer.messageText.text = Viewer.messages[Viewer.now];
    }

    public void next()
    {
        if (Viewer.now < Viewer.messages.Length - 1)
        {
            Skip.blocksRaycasts = true;
            Next.blocksRaycasts = false;
        
            Viewer.now++;
            Viewer.messageText.text = " ";
            Viewer.messageText.DOText(Viewer.messages[Viewer.now], PlayerPrefs.GetInt("msg_duration", 4));
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PrepareScreen>().isStart)
        {
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Viewer.now < Viewer.messages.Length - 1)
            {
                Viewer.now += 1;
                Viewer.messageText.text = Viewer.messages[Viewer.now];
            }

            if (Viewer.messageText.text == Viewer.messages[Viewer.now])
            {
                skip();
            }
        }
    }
}
