
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static AllData allData;

    private static UnityEvent updateMoneyEvent = new UnityEvent();
   static DataPlayer()
    {
        //Chuyển dữ liệu từ JSON sang ALLDATA
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));

        //Nếu dữ liệu là null tức là lần đầu lưu dữ liệu
        //Do đó cần khởi tạo mặc định cho user
        if(allData == null)
        {
            var gunDefaulId = 1;
            allData = new AllData
            {
                listGun = new List<int> { gunDefaulId },
                currentGun = gunDefaulId,
                gem = 2000
            };
            SaveData();
        }
    }

    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }

    public static bool IsOwnedGun(int id) 
    { 
        return allData.listGun.Contains(id); 
    }

    public static void AddGunOwnedData(int id)
    {
        allData.listGun.Add(id);

        SaveData();
    }
    public static int GetGem()
    {
        return allData.GetGem();
    }
    public static void AddGem(int value)
    {
        allData.AddGem(value);

        updateMoneyEvent?.Invoke();
        SaveData();
    }
    public static void SubGem(int value)
    {
        allData.SubGem(value);

        updateMoneyEvent?.Invoke();
        SaveData();
    }
    public static bool IsEnoughMoney(int cost)
    {
        return allData.isEnoughMoney(cost);
    }
    public static void AddListenEvent(UnityAction updateMoney)
    {
        updateMoneyEvent.AddListener(updateMoney);
    }
    public static void RomoveListenEvent(UnityAction updateMoney)
    {
        updateMoneyEvent.RemoveListener(updateMoney);
    }
}
public class AllData
{
    public List<int> listGun;
    public static AllData Instance;
    public int currentGun;
    public int gem;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public bool IsOwnedGun(int id)
    {
        return listGun.Contains(id);
    }
    public void AddGunOwnedData(int id)
    {
        if (IsOwnedGun(id))
        {
            return;
        }
        else
        {
            listGun.Add(id);
        }
    }
    public int GetGem()
    {
        return gem;
    }
    public void AddGem(int value)
    {
        gem += value;
    }
    public void SubGem(int value)
    {
        gem -= value;
    }
    public bool isEnoughMoney(int cost)
    {
        return gem >= cost;
    }
}
