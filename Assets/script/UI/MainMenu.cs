using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button quitBtn;
    [SerializeField] Button settingBtn;
    void Start()
    {
        startBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();

        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(QuitGame);
    }
    public void StartGame()
    {
        startBtn.interactable = false;

        TMP_Text buttonText = startBtn.GetComponentInChildren<TMP_Text>();

        AudioClip clip = Audio.instance.OnStartGame();

        StartCoroutine(WaitForAudioThenAnimateAndLoad(clip, buttonText));
    }
    private System.Collections.IEnumerator WaitForAudioThenAnimateAndLoad(AudioClip clip, TMP_Text buttonText)
    {
        if (clip != null)
        {
            yield return new WaitForSeconds(clip.length); // đợi clip phát xong
        }

        Sequence seq = DOTween.Sequence();
        for (int i = 0; i < 3; i++)
        {
            seq.Append(buttonText.DOFade(0f, 0.1f));
            seq.Append(buttonText.DOFade(1f, 0.1f));
        }

        seq.OnComplete(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });
    }
    public void QuitGame()
    {
        Audio.instance.OnButtonClicked();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
    public void OnSettingOpened()
    {
        Audio.instance.OnButtonClicked();
    }
}
