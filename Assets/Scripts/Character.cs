﻿using UnityEngine;
using DG.Tweening;
using Yarn.Unity;
using System.Collections;

public class Character : MonoBehaviour
{
    public SpriteRetriever SpriteManager;
    public SpriteRenderer FacialRenderer;

    public MeshRenderer TintMesh;
    private Material TintMaterial;


    [Header("Appear")]
    public Vector3 offScreen;
    public Vector3 peeking;
    public Vector3 onScreen;
    public float appearDuration;
    public float peekDuration;
    public float disappearDuration;

    private Vector3 screenEdgePosition;

    private Coroutine _shakeRoutine;

    private Coroutine _tintRoutine;
    private Color _albedoStartColor;

    private void Start()
    {
        screenEdgePosition = GetScreenEdgePosition();

        offScreen = screenEdgePosition + ((screenEdgePosition - onScreen) * 2);
        transform.position = offScreen;

        if (TintMesh)
        {
            TintMaterial = TintMesh.material;
            _albedoStartColor = TintMaterial.color;
        }
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

    [YarnCommand("Wiggle")]
    public void Wiggle()
    {
        if (_shakeRoutine != null)
        {
            StopCoroutine(_shakeRoutine);
            transform.rotation = Quaternion.identity;
        }

        _shakeRoutine = StartCoroutine(WiggleRoutine(0.5f));
    }

    private IEnumerator WiggleRoutine(float time)
    {
        float angle = 7f;
        float speed = 30f;
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            float r = Mathf.Sin(elapsedTime * speed) * angle;
            transform.rotation = Quaternion.Euler(0, r, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.identity;
    }

    [YarnCommand("TintOn")]
    public void TintOn(string color)
    {
        if (_tintRoutine != null)
        {
            StopCoroutine(_tintRoutine);
        }

        Color targetColor = Color.white;

        if (color == "RED")
        {
            targetColor = Color.red;
        }
        else if (color == "BLACK")
        {
            targetColor = Color.black;
        }

        _tintRoutine = StartCoroutine(TintToColor(targetColor));
    }

    [YarnCommand("TintOff")]
    public void TintOff()
    {
        if (_tintRoutine != null)
        {
            StopCoroutine(_tintRoutine);
        }

        _tintRoutine = StartCoroutine(TintToColor(_albedoStartColor));
    }

    private IEnumerator TintToColor(Color targetColor)
    {
        Color startColor = TintMaterial.color;
        float t = 0f;
        float maxTime = 0.5f;
        while (t < maxTime)
        {
            float tn = t * (1 / maxTime);
            TintMaterial.color = Color.Lerp(startColor, targetColor, tn);
            t += Time.deltaTime;
            yield return null;
        }
        TintMaterial.color = targetColor;
    }

}
