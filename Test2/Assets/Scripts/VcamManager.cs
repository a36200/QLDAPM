using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamManager : MonoBehaviour
{
    public GameObject Vcam1;
    public GameObject Vcam2;


    public static VcamManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Vcam1ToVcam2()
    {
        Vcam1.SetActive(false);
    }
}
