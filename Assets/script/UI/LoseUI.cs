using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loseTitle;
    [SerializeField] Image bgImage;
    [SerializeField] Button replayButton;
    [SerializeField] Button exitButton;
    [SerializeField] CanvasGroup buttons;
    void Awake()
    {
        loseTitle.alpha = 0;
        buttons.alpha = 0;

        Color c = bgImage.color;
        c.a = 0f;
        bgImage.color = c;
    }
    void Start()
    {
        Audio.instance.changeMusicDefeat();

        Sequence seq = DOTween.Sequence();
        seq.Append(bgImage.DOFade(1f, 1f).SetEase(Ease.InOutQuad));
        seq.Append(loseTitle.DOFade(1f, 1f).SetEase(Ease.InOutQuad));
        seq.Append(buttons.DOFade(1f, 1f).SetEase(Ease.InOutQuad));
    }
    public void Retry()
    {
        Debug.Log("retry");
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Debug.Log("exit");
        SceneManager.LoadScene("Title");
    }
    public void PlayBtnSound()
    {
        Audio.instance.OnButtonClicked();
    }
}
