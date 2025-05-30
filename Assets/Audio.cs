using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public static Audio instance;

    [Header("camara")]
    [SerializeField] Camera _camera;
    AudioSource _audio;

    [Header("music")]
    public AudioClip musicBegin;
    [Range(0f, 1f)]
    public float takingMusicBeginVolume = 1f;



    public AudioClip takeDame;
    [Range(0f, 1f)]
    public float takingDamageVolume = 1f;


    public AudioClip hit;
    [Range(0f, 1f)]
    public float takingHitVolume = 1f;

    public AudioClip musicBoss;
    [Range(0f, 1f)]
    public float takingmusicBoss = 1f;

    public AudioClip musicVictory;
    [Range(0f, 1f)]
    public float takingmusicVictory = 1f;

    public AudioClip playerDash;
    [Range(0f, 1f)]
    public float takingplayerDash = 1f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    void Start()
    {
        _audio = _camera.GetComponent<AudioSource>();
        MusicBegin();
    }
    void ChangeMusic(AudioClip clip, float _volume)
    {
        _audio.clip = clip;
        _audio.volume = _volume;
        _audio.Play();
    }

    void MusicBegin() => ChangeMusic(musicBegin, takingMusicBeginVolume);

    public void changeMusicBoss() => ChangeMusic(musicBoss, takingmusicBoss);
    public void changeMusicVictory() => ChangeMusic(musicVictory, takingmusicVictory);




    void OnPlayClip(AudioClip audio, float volume) => AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, volume);

    public void OnPlayAudioHit() => OnPlayClip(hit, takingHitVolume);

    public void OnPlayTakeDame() => OnPlayClip(takeDame, takingDamageVolume);
    
    public void OnPlayerDash() => OnPlayClip(playerDash, takingplayerDash);
}
