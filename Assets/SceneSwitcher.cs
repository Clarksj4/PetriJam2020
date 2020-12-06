using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public Button button;
    public Image FadeImage;

    private void Awake()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
        DontDestroyOnLoad(gameObject);
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        bool isStartScene = scene.name == "StartScene";
        button.gameObject.SetActive(isStartScene);
        FadeImage.gameObject.SetActive(isStartScene);

        if (isStartScene)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(FadeImage.DOFade(0f, 1f));
        }
    }

    [YarnCommand("SwitchToScene")]
    public void SwitchToScene(string scene)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(FadeImage.DOFade(1f, 2f));
        sequence.OnComplete(() => {
            //SceneManager.LoadScene("DialogueScene");
            SceneManager.LoadScene(scene);
        });
        sequence.Play();
    }
}
