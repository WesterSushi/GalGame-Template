using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryReader : MonoBehaviour
{
    public TextAsset zh_CN, zh_TW, en_US, jp_JP;
    public string[] zh_CN_str, zh_TW_str, en_US_str, jp_JP_str;
    private void Start()
    {
        if (zh_CN != null) zh_CN_str = zh_CN.text.Split("\n");
        if (zh_TW != null) zh_TW_str = zh_TW.text.Split("\n");
        if (en_US != null) en_US_str = en_US.text.Split("\n");
        if (jp_JP != null) jp_JP_str = jp_JP.text.Split("\n");
    }
}
