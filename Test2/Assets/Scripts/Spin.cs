using System.Collections;
using System.Collections.Generic;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public int numberGift = 10;
    public float timeRotate;
    public float numberCircleRotate;
    public AnimationCurve curve;

    private const float circle = 360f;
    private float angleOfOneGift;
    private float currentTime;

    public Transform parrent;

    private void Start()
    {
        angleOfOneGift = circle / numberGift;

    }
    IEnumerator RotateWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int indexGiftRandom = Random.Range(1, numberGift);
        float angleWant = (numberCircleRotate * circle) + angleOfOneGift * indexGiftRandom;
        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWant * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent);
        }
    }
}
