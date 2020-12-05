using UnityEngine;
using Yarn.Unity;

public class SFXManager : MonoBehaviour
{
    public AudioSource[] Tracks;

    [YarnCommand("PlaySFXByName")]
    public void PlaySFXByName(string name)
    {
        foreach (AudioSource track in Tracks)
        {
            // Play the named clip
            if (track.clip.name == name)
                track.Play();
        }
    }
}
