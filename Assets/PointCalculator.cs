using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointCalculator : MonoBehaviour
{
    public GameObject playerGameObject;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Points: " + playerGameObject.transform.position.z.ToString("0.00");
    }
}
