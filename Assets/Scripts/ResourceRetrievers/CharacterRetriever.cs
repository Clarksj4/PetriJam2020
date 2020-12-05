using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterRetriever")]
public class CharacterRetriever : ScriptableObject
{
    public Character[] Characters;

    public Character GetCharacterByName(string name)
    {
        Character chosen = Characters.First(c => c.name == name);
        Character copy = Instantiate(chosen, null, false);
        copy.name = name;
        copy.transform.position = copy.offScreen;
        return copy;
    }
}
