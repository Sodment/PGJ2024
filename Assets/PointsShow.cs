using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsShow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pointText;


    private void Start()
    {
        pointText.text = PlayerPrefs.GetString("Points", "0.00");
    }
}
