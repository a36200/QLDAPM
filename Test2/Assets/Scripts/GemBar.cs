using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemBar : MonoBehaviour
{
    public Text textGem;

    public void UpdateView()
    {
        textGem.text = DataPlayer.GetGem().ToString();
    }
    private void OnEnable()
    {
        DataPlayer.AddListenEvent(UpdateView);
    }
    private void OnDisable()
    {
        DataPlayer.RomoveListenEvent(UpdateView);
    }
}
