using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class WinUI : MonoBehaviour
{
    [SerializeField] GameObject winTitle;
    [SerializeField] TextMeshProUGUI toTitleBtn;
    public float dropDistance = 10f;   
    public float dropDuration = 1f;     
    public Ease easing = Ease.OutBounce;
    void Awake()
    {
        winTitle.transform.localPosition = Vector3.zero;
        toTitleBtn.alpha = 0f;
    }
    void Start()
    {
        Vector3 startPos = winTitle.transform.position + Vector3.up * dropDistance;
        winTitle.transform.position = startPos;

        Sequence seq = DOTween.Sequence();

        seq.Append(winTitle.transform.DOMoveY(startPos.y - dropDistance, dropDuration)
                 .SetEase(easing));
        seq.Append(toTitleBtn.DOFade(1f, 1f).SetEase(Ease.InOutQuad));
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
