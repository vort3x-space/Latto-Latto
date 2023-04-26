using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialPanel : PanelBase
{

    [SerializeField] Image finger;
    [SerializeField] Text text;
    private void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 scale = text.transform.localScale;
        Vector2 fingerPos = finger.transform.position;
        mySequence.Append(finger.transform.DOMoveY(finger.transform.position.y - 200, 1f).SetEase(Ease.InQuad))
          .Join(text.transform.DOScale(scale * 1.3f, 1).SetEase(Ease.Flash))
          .Append(text.transform.DOScale(scale * 1, 1).SetEase(Ease.Flash))
          .Join(finger.transform.DOMoveY(finger.transform.position.y, .5f))
          .SetLoops(-1);
        }
}
