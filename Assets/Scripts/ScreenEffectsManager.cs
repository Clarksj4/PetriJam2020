using UnityEngine;
using Yarn.Unity;
using System.Collections.Generic;
using System.Linq;

public class ScreenEffectsManager : MonoBehaviour
{
    public ScreenEffect[] Effects;

    private List<ScreenEffect> currentEffects = new List<ScreenEffect>();

    [YarnCommand("PlayEffect")]
    public void PlayEffect(string name)
    {
        ScreenEffect effect = Effects.First(e => e.name == name);
        ScreenEffect copy = Instantiate(effect);
        copy.name = name;
        currentEffects.Add(copy);
        copy.Play();
    }

    [YarnCommand("StopEffect")]
    public void StopEffect(string name)
    {
        ScreenEffect effect = currentEffects.FirstOrDefault(e => e.name == name);
        if (effect != null)
            effect.Stop();
    }
}
