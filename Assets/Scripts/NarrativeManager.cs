using UnityEngine;
using Yarn.Unity;
using DG.Tweening;

public class NarrativeManager : MonoBehaviour
{
    public CharacterManager CharacterManager;

    private Character currentCharacter;

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
