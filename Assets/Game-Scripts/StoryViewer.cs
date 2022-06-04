using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StoryViewer : MonoBehaviour
{
    [HideInInspector] public StoryReader storyReader;
    public Text messageText;
    public String[] messages;
    public int now = 0;
    private void Start()
    {
        storyReader = FindObjectOfType<StoryReader>();
        switch (Application.systemLanguage)
        {
            case SystemLanguage.ChineseSimplified:
                messages = storyReader.zh_CN_str;
                break;
            case SystemLanguage.ChineseTraditional:
                messages = storyReader.zh_TW_str;
                break;
            case SystemLanguage.English:
                messages = storyReader.en_US_str;
                break;
            case SystemLanguage.Japanese:
                messages = storyReader.jp_JP_str;
                break;
        }

        messageText.DOText(messages[now], PlayerPrefs.GetInt("msg_duration",4));
    }
}
