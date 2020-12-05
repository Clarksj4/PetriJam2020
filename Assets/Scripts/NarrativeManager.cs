﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NarrativeManager : MonoBehaviour
{
    public GameObject otherText;
    public GameObject selfText;

    [YarnCommand("ShowNarrator")]
    public void ShowNarrator(string other)
    {
        bool showOther = other == "other";
        ShowNarrator(showOther);
    }

    public void ShowNarrator(bool other)
    {
        otherText.SetActive(other);
        selfText.SetActive(!other);
    }
}