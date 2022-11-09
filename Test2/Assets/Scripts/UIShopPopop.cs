using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIShopPopop : MonoBehaviour
{
    public UIShopElement[] shopElements;
    // Start is called before the first frame update
    private void OnValidate()
    {

        if (shopElements == null || shopElements.Length == 0)
        {
            shopElements = GetComponentInChildren<UIShopElement[]>();
        }
    }
    private void SetData()
    {
        for(int i = 0; i < shopElements.Length; i++)
        {
            shopElements[i].SetData(i + 1);
        }
    }
    private void Awake()
    {
        SetData();
    }
}
