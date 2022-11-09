using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
    public int id;
    public int cost;

    public Text costText;
    public Button purchaseButton;

    private GameObject prefab;
    private GameObject gunItem;
    private void Awake()
    {
        purchaseButton.onClick.AddListener(OnPurchase);
        UpdateView();
    }

    public void SetData(int id)
    {
        this.id = id;
        cost = id * 100;

        InstantiateGuns();

        UpdateView();
    }
    private void InstantiateGuns()
    {
        prefab = Resources.Load<GameObject>($"Guns/id");
        gunItem = Instantiate(prefab,transform);
    }
    public void UpdateView()
    {
        //Check súng có đang sở hữu hay không
        var isOwned = DataPlayer.IsOwnedGun(id);

        if (isOwned)
        {
            purchaseButton.enabled = false;
            costText.text = "Owned";
        }
        else
        {
            purchaseButton.enabled=true;
            costText.text = cost.ToString();
        }
    }
    public void UnlockTypeItems()
    {

    }
    private void OnPurchase()
    {
        var canPurchase = DataPlayer.IsEnoughMoney(cost);
        if (canPurchase)
        {
            DataPlayer.AddGunOwnedData(id);
            UpdateView();
            DataPlayer.SubGem(cost);
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }
}
