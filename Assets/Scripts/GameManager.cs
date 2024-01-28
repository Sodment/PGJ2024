using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenSee;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public OpenSee.OpenSee openSee;
    public EnemyFOV enemyFOV;

    public static GameManager instance;

    public Sprite nonSmillingIcon, smillingIcon;
    public Image smillingImage;
    public Animator playerAnimator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager in scene!");
        }

        //URUCHOMIENIE TRACKINGU TWARZY AUUUUUUUUU
        System.Diagnostics.Process.Start("CMD.exe", "start cmd /k \" cd  OpenSeeFace-v1.20.4/Binary && Call run.bat \" "); //Start cmd process

    }

    private void Update()
    {
        bool smileToggle = false;
        if (openSee.GetOpenSeeData(0) != null)
        {
            float smile = openSee.GetOpenSeeData(0).features.MouthCornerUpDownLeft;
            smileToggle = -smile > 0.2f ? true : false;
        }

        smillingImage.sprite = smileToggle ? smillingIcon : nonSmillingIcon;

        Player.SetSmileState(smileToggle);
        playerAnimator.SetBool("Smiling", smileToggle);
        Player.Update();
    }

    public void EnemySeePlayer()
    {
        bool smileToggle = false;
        if (openSee.GetOpenSeeData(0) != null)
        {
            float smile = openSee.GetOpenSeeData(0).features.MouthCornerUpDownLeft;
            smileToggle = -smile > 0.2f ? true : false;
        }

        if (!smileToggle)
        {
            Player.TakeSus(15f);
        }


    }


}
