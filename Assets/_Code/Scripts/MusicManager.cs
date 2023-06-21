using UnityEngine;

namespace _Code.Scripts.ScriptableObject
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip clip_hit;

        public void PlayHit()
        {
            audioSource.clip = clip_hit;
            audioSource.Play();
        }
    }
}