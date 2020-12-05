using System;
using System.Linq;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public List<AudioSource> Tracks;
    private List<float> MaxVolumes = new List<float>();

    private void Start()
    {
        // Current volume is considered max volume.
        for (int i = 0; i < Tracks.Count; i++)
            MaxVolumes.Add(Tracks[i].volume);
    }

    [YarnCommand("PlayTrackByName")]
    public void PlayTrackByName(string name)
    {
        int index = IndexOfTrack(name);
        float volume = MaxVolumes[index];

        for (int i = 0; i < Tracks.Count; i++)
        {
            if (i == index)
                FadeInTrack(Tracks[i], volume);
            else
                FadeOutTrack(Tracks[i]);
        }
    }

    [YarnCommand("StopMusic")]
    public void StopMusic()
    {
        foreach (AudioSource track in Tracks)
            FadeOutTrack(track);
    }

    private void FadeInTrack(AudioSource track, float volume)
    {
        track.volume = 0;
        track.Play();
        track.DOFade(volume, 1f);
    }

    private void FadeOutTrack(AudioSource track)
    {
        track.DOFade(0f, 1f);
    }

    private int IndexOfTrack(string name)
    {
        for (int i = 0; i < Tracks.Count; i++)
        {
            if (Tracks[i].clip.name == name)
                return i;
        }

        return -1;
    }
}
