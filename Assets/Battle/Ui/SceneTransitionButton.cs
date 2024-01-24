using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(Execute);
    }

    private void Execute()
    {
        if (_isFading) return;
        StartCoroutine(FadeOut(TransitionScene));
    }

    [Header("Transition Scene Info")]
    [SerializeField]
    private bool _isReloadThisScene;
    [SerializeField]
    private string _nextSceneName;

    private void TransitionScene()
    {
        if (_isReloadThisScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }

    [Header("Fade")]
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private Color _fadeImageStartColor;
    [SerializeField]
    private Color _fadeImageEndColor;

    private static bool _isFading = false;

    private IEnumerator FadeOut(Action onComplete)
    {
        if (_isFading) yield break;
        _isFading = true;
        for (float t = 0; t < _fadeDuration; t += Time.deltaTime)
        {
            _fadeImage.color = Color.Lerp(_fadeImageStartColor, _fadeImageEndColor, t / _fadeDuration);
            yield return null;
        }
        _fadeImage.color = _fadeImageEndColor;
        _isFading = false;
        onComplete?.Invoke();
    }
}