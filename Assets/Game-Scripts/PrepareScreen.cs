using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PrepareScreen : MonoBehaviour
{
    public CanvasGroup PreparGroup;
    public StoryViewer reader;
    public bool isRunning;

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        PreparGroup.DOFade(0f, 1f).SetEase(Ease.OutSine);
        yield return new WaitForSeconds(1f);
        reader.enabled = true;
        isRunning = true;
    }
}
