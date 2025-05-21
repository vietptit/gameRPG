using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip takeDame;
    [Range(0f, 1f)]
    public float takingDamageVolume = 1f;


    public AudioClip Blaze;
    [Range(0f, 1f)]
    public float takingBlazeVolume = 1f;





    void OnPlayClip(AudioClip audio, float volume) => AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, volume);

    public void OnPlayAudioBlaze() => OnPlayClip(Blaze, takingDamageVolume);

    public void OnPlayTakeDame() => OnPlayClip(takeDame, takingDamageVolume);
}
