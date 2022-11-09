using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        UIManager.Instance.enableTapToPlay(true);
    }

    // Update is called once per frame
    void Update()
    {
        TapToPlay();    
    }
    public void TapToPlay()
    {
        if (Input.GetMouseButton(0))
        {
            Time.timeScale = 1;
            UIManager.Instance.enableTapToPlay(false);
            VcamManager.Instance.Vcam1ToVcam2();
        }
    }
}
