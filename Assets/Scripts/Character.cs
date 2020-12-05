using UnityEngine;
using DG.Tweening;
using Yarn.Unity;

public class Character : MonoBehaviour
{
    public SpriteManager SpriteManager;
    public SpriteRenderer FacialRenderer;

    // Removes this character from the scene
    public void Remove()
    {
        Destroy(gameObject);
    }

    [YarnCommand("SetFacialExpression")]
    public void SetFacialExpression(string expression)
    {
        FacialRenderer.sprite = SpriteManager.GetSpriteByName(expression);
    }

    [YarnCommand("PunchUp")]
    public void PunchUp()
    {
        transform.DOPunchPosition(Vector3.up * 0.15f, 0.5f);
    }
}
