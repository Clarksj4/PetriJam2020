using UnityEngine;
using DG.Tweening;
using Yarn.Unity;

public class Character : MonoBehaviour
{
    public SpriteRetriever SpriteManager;
    public SpriteRenderer FacialRenderer;
    [Header("Appear")]
    public Vector3 offScreen;
    public Vector3 peeking;
    public Vector3 onScreen;
    public float appearDuration;
    public float peekDuration;
    public float disappearDuration;

    private Vector3 screenEdgePosition;

    private void Start()
    {
        screenEdgePosition = GetScreenEdgePosition();

        offScreen = screenEdgePosition + ((screenEdgePosition - onScreen) * 2);
        transform.position = offScreen;
    }

    private Vector3 GetScreenEdgePosition()
    {
        // TODO: get side of screen point
        Ray edgeRay = Camera.main.ScreenPointToRay(new Vector2(0, Screen.height / 2));
        Plane plane = new Plane(edgeRay.origin, Vector3.zero);

        if (plane.Raycast(edgeRay, out var enter))
            return edgeRay.GetPoint(enter);

        return peeking;
    }

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

    [YarnCommand("Peek")]
    public void Peek()
    {
        transform.DOMove(screenEdgePosition, peekDuration).SetEase(Ease.OutSine);
    }


    [YarnCommand("Appear")]
    public void Appear()
    {
        transform.DOMove(onScreen, appearDuration).SetEase(Ease.OutSine);
    }

    [YarnCommand("Disappear")]
    public void Disappear()
    {
        transform.DOMove(-offScreen, disappearDuration).SetEase(Ease.OutSine);
    }

    [YarnCommand("PunchUp")]
    public void PunchUp()
    {
        transform.DOPunchPosition(Vector3.up * 0.15f, 0.5f);
    }
}
