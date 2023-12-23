using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClearAnimation : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private string _message;
    [SerializeField] private float _gameclearDelaytime;
    [SerializeField] private float _starImageDelaytime;
    [SerializeField] private Image[] _starImage;

    public IEnumerator GameClearImageAnimation()
    {
        image.enabled = true;
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator StarImageAnimationStart(int starCount)
    {
        for (int i = 0; i < starCount; i++)
        {
            StartCoroutine(StarImageAnimation(_starImage[i]));
            yield return new WaitForSeconds(_starImageDelaytime);
        }
    }

    public IEnumerator StarImageAnimation(Image image)
    {
        yield return null;
        image.enabled = true;
        image.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        var sequence = DOTween.Sequence();
        sequence.Append(image.GetComponent<RectTransform>().DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f))
                .Append(image.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.3f));
    }

    public IEnumerator CharaImageAnimation(Image image, Vector2 pos)
    {
        yield return null;
        image.GetComponent<RectTransform>().DOAnchorPos(new Vector2(pos.x, pos.y),1f);
    }

    //public IEnumerator ScenarioAnimation(Image TextBox)
    //{

    //}
}
