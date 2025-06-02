using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{

    public static Audio instance;

    [Header("camara")]
    [SerializeField] Camera _camera;
    AudioSource _audio;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

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

    public AudioClip musicVictory; // bo di
    [Range(0f, 1f)]
    public float takingmusicVictory = 1f;

    public AudioClip musicDefeat;
    [Range(0f, 1f)]
    public float takingmusicDefeat = 1f;

    public AudioClip playerDash;
    [Range(0f, 1f)]
    public float takingplayerDash = 1f;

    public AudioClip startGame;
    [Range(0f, 1f)]
    public float takingstartGame = 1f;

    public AudioClip buttonSfx;
    [Range(0f, 1f)]
    public float takingbuttonSfx = 1f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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

    public void changeMusicDefeat() => ChangeMusic(musicDefeat, takingmusicDefeat);


    void OnPlayClip(AudioClip audio, float volume) => AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, volume);

    public void OnPlayAudioHit() => OnPlayClip(hit, takingHitVolume);

    public void OnPlayTakeDame() => OnPlayClip(takeDame, takingDamageVolume);

    public void OnPlayerDash() => OnPlayClip(playerDash, takingplayerDash);
    public void OnButtonClicked() => OnPlayClip(buttonSfx, takingbuttonSfx);

    public AudioClip OnStartGame()
    {
        OnPlayClip(startGame, takingstartGame);
        return startGame;
    } 

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _camera = Camera.main;

        if (_camera != null)
        {
            _audio = _camera.GetComponent<AudioSource>();
            _audio.volume = musicVolume;

            if (_audio == null)
            {
                _audio = _camera.gameObject.AddComponent<AudioSource>();
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (_audio != null)
        {
            _audio.volume = musicVolume;
        }
    }
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);

        takingDamageVolume = sfxVolume;
        takingHitVolume = sfxVolume;
        takingplayerDash = sfxVolume;
        takingstartGame = sfxVolume;
        takingbuttonSfx = sfxVolume;
    }
}
