using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteManager")]
public class SpriteManager : ScriptableObject
{
    public Sprite[] Sprites;

    public Sprite GetSpriteByName(string name)
    {
        return Sprites.First(s => s.name == name);
    }
}
