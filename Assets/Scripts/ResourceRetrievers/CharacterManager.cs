using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterManager")]
public class CharacterManager : ScriptableObject
{
    public Character[] Characters;

    public Character GetCharacterByName(string name)
    {
        Character chosen = Characters.First(c => c.name == name);
        Character copy = Instantiate(chosen);
        copy.name = name;
        return copy;
    }
}
