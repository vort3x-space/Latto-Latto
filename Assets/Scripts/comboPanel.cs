using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class comboPanel : PanelBase
{

    [SerializeField] Image finger;
    [SerializeField] TMP_Text text; 
    private void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 scale = text.transform.localScale;
        Vector2 fingerPos = finger.transform.position;
        mySequence.Append(text.transform.DOScale(scale * 2f, .2f).SetEase(Ease.Flash))
            .Append(text.transform.DOScale(scale * 1, .3f).SetEase(Ease.Flash))
            .SetLoops(-1);
    }
}