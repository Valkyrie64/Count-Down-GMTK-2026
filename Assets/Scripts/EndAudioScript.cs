using UnityEngine;

public class EndAudioScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip audioClip;
    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = audioClip;
            audio.loop = true;
            audio.Play();
        }
    }
}
