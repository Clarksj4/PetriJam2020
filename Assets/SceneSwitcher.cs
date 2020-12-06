using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneSwitcher : MonoBehaviour
{
    public Image FadeImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchToScene(string scene)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(FadeImage.DOFade(1f, 2f));
        sequence.OnComplete(() => {
            //SceneManager.LoadScene("DialogueScene");
            SceneManager.LoadScene(scene);
        });
    }
}
