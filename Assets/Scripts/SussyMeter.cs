using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SussyMeter : MonoBehaviour
{
    public float sussyValue = 0f;
    public Image sussyMetalImage;
    public float incementValue = 0.005f;

    public void EnemyLookAtPlayer()
    {
        sussyValue += incementValue;
    }

    private void Update()
    {
        sussyMetalImage.fillAmount = sussyValue;
    }
}
