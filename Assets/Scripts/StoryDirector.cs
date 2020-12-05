using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class StoryDirector : MonoBehaviour
{
    public CharacterRetriever CharacterManager;
    public Image FadeImage;
    public DialogueRunner dialogRunner;
    private Character currentCharacter;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        dialogRunner.StartDialogue();
    }

    [YarnCommand("FadeInScene")]
    public void FadeInScene()
    {
        FadeImage.DOFade(0f, 1f);
    }

    [YarnCommand("FadeOutScene")]
    public void FadeOutScene()
    {
        FadeImage.DOFade(1f, 1f);
    }

    [YarnCommand("ZoomInCamera")]
    public void ZoomInCamera()
    {
        Transform cameraTransform = Camera.main.transform;
        cameraTransform.DOMoveZ(cameraTransform.position.z + 2f, 0.5f).SetEase(Ease.OutCubic);
    }

    [YarnCommand("ZoomOutCamera")]
    public void ZoomOutCamera()
    {
        Transform cameraTransform = Camera.main.transform;
        cameraTransform.DOMoveZ(cameraTransform.position.z - 2f, 0.5f).SetEase(Ease.OutCubic);
    }

    [YarnCommand("SetCharacter")]
    public void SetCharacter(string name)
    {
        // Remove current character
        if (currentCharacter != null)
            currentCharacter.Remove();

        // Add new character
        currentCharacter = CharacterManager.GetCharacterByName(name);
    }

    // TODO: Go to another scene
    [YarnCommand("SceneChange")]
    public void SceneChange(string sceneName)
    {

    }
}
