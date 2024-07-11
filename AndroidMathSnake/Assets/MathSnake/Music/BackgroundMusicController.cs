#nullable enable

using MathSnake.Exceptions;
using UnityEngine;

namespace MathSnake.Music
{
    public class BackgroundMusicController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[]? musicClips;

        [SerializeField]
        private AudioSource? audioSource;

        private AudioClip[] MusicClips => SerializeFieldNotAssignedException.ThrowIfNull(musicClips);

        private AudioSource AudioSource => SerializeFieldNotAssignedException.ThrowIfNull(audioSource);

        public void StartBackgroundMusic()
        {
            var clip = MusicClips[Random.Range(0, MusicClips.Length)];
            AudioSource.clip = clip;
            AudioSource.Play();
        }

        public void StopBackgroundMusic()
        {
            AudioSource.Stop();
        }
    }
}

