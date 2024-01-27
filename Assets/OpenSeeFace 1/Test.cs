using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenSee;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public OpenSee.OpenSee openSee;
    [SerializeField]
    float smile = 0f;
    [SerializeField]
    bool smileToggle;

    public Sprite smileSprite, nonSmileSprite;
    public Image smileImage;

    private void Awake()
    {
        System.Diagnostics.Process.Start("CMD.exe", "start cmd /k \" cd  OpenSeeFace-v1.20.4/Binary && Call run.bat \" "); //Start cmd process
    }

    // Update is called once per frame
    void Update()
    {
        smile = openSee.GetOpenSeeData(0).features.MouthCornerUpDownLeft;

        smileToggle = -smile > 0.4f ? true : false;
        smileImage.sprite = smileToggle ? smileSprite : nonSmileSprite;
        
    }
}
