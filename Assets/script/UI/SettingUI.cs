using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] GameObject setting;
    [SerializeField] Button controlTab;
    [SerializeField] Button audioTab;
    [SerializeField] GameObject controlUI;
    [SerializeField] GameObject audioUI;
    [SerializeField] GameObject selected1;
    [SerializeField] GameObject selected2;
    void Start()
    {
        setting.SetActive(false);

        audioTab.onClick.RemoveAllListeners();
        controlTab.onClick.RemoveAllListeners();

        audioTab.onClick.AddListener(ShowAudioUI);
        controlTab.onClick.AddListener(ShowControlUI);
    }
    private void ShowControlUI()
    {
        audioUI.SetActive(false);
        controlUI.SetActive(true);
        selected1.SetActive(true);
        selected2.SetActive(false);
    }
    private void ShowAudioUI()
    {
        controlUI.SetActive(false);
        audioUI.SetActive(true);
        selected2.SetActive(true);
        selected1.SetActive(false);
    }
}
