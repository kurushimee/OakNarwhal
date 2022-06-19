using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Audio Events/Composite")]
public class CompositeAudioEvent : AudioEvent
{
    public CompositeEntry[] entries;

    public override void Play(AudioSource source)
    {
        float totalWeight = 0;
        for (var i = 0; i < entries.Length; ++i)
            totalWeight += entries[i].weight;

        var pick = Random.Range(0, totalWeight);
        for (var i = 0; i < entries.Length; ++i)
        {
            if (pick > entries[i].weight)
            {
                pick -= entries[i].weight;
                continue;
            }

            entries[i].@event.Play(source);
            return;
        }
    }

    [Serializable]
    public struct CompositeEntry
    {
        public AudioEvent @event;
        public float weight;
    }
}