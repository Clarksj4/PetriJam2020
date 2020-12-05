using UnityEngine;
using Yarn.Unity;
using DG.Tweening;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] Tracks;

    [YarnCommand("PlayTrackByName")]
    public void PlayTrackByName(string name)
    {
        foreach (AudioSource track in Tracks)
        {
            // Play the named clip
            if (track.clip.name == name)
                FadeInTrack(track);

            // Stop all other clips
            else
                FadeOutTrack(track);
        }
    }

    private void FadeInTrack(AudioSource track)
    {
        track.volume = 0;
        track.Play();
        track.DOFade(1f, 1f);
    }

    private void FadeOutTrack(AudioSource track)
    {
        track.DOFade(0f, 1f);
    }
}
