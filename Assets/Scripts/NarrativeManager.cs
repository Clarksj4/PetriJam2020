using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public SpriteManager SpriteManager;
    public SpriteRenderer characterImage;

    private void Start()
    {
        // Test
        SetCharacter("Sally");
    }

    // Change who we're talking to
    public void SetCharacter(string name)
    {
        characterImage.sprite = SpriteManager.GetSpriteByName(name);
    }
    
    // TODO: Go to another scene
}
