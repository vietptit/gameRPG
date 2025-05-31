using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button quitBtn;
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
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
