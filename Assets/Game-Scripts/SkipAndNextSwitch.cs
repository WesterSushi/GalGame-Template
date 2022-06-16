using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAndNextSwitch : MonoBehaviour
{
    public StoryViewer Viewer;
    public CanvasGroup Skip, Next;
    public CanvasGroup DarkScreen;

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
        else
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PrepareScreen>().isRunning)
        {
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
            {
                if (Viewer.now < Viewer.messages.Length - 1)
                {
                    Viewer.now += 1;
                    Viewer.messageText.text = Viewer.messages[Viewer.now];
                }
                else
                {
                    FindObjectOfType<PrepareScreen>().isRunning = false;
                    StartCoroutine(LoadNextScene());
                }
            }

            if (Viewer.messageText.text == Viewer.messages[Viewer.now])
            {
                skip();
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        DarkScreen.DOFade(1f, 1f).SetEase(Ease.OutSine);
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadSceneAsync(Application.loadedLevel + 1);
    }
}
