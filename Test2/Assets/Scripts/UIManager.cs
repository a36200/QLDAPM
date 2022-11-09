using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject textTapToPlay;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
    }
    private void Update()
    {
        animTapToPlay();
    }
    public void enableTapToPlay(bool isActive)
    {
        textTapToPlay.SetActive(isActive);
    }
    public void animTapToPlay()
    {
        textTapToPlay.transform.DOScale(Vector3.zero, 2).SetEase(Ease.OutBack).OnComplete(() =>
        {
            //textTapToPlay.transform.DOScale(Vector3.one, 2).SetEase(Ease.OutBounce).SetDelay
        });
    }
}
