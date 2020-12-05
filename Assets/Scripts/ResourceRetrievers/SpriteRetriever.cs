using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteRetriever")]
public class SpriteRetriever : ScriptableObject
{
    public Sprite[] Sprites;

    public Sprite GetSpriteByName(string name)
    {
        return Sprites.First(s => s.name == name);
    }
}
