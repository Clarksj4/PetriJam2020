using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using System.Collections;

public class StoryDirector : MonoBehaviour
{
    public CharacterRetriever CharacterManager;
    public SpriteRenderer background;
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
        background.DOFade(1f, 2f);
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
        // TODO: Remove current character
        if (currentCharacter != null)
            currentCharacter.Remove();

        // TODO: Add new character
        currentCharacter = CharacterManager.GetCharacterByName(name);

        // TODO: put it somewhere...
    }

    // TODO: Go to another scene
    [YarnCommand("SceneChange")]
    public void SceneChange(string sceneName)
    {

    }
}
