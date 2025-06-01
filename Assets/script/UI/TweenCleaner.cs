using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TweenCleaner : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void OnSceneUnloaded(Scene scene)
    {
        DOTween.KillAll(); 
    }
}