using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateIndicators : MonoBehaviour
{
    [SerializeField] Image playerHPBar;
    [SerializeField] Image playerSusBar;

    private void Update()
    {
        playerHPBar.fillAmount = Player.GetHPPercentage();
        playerSusBar.fillAmount = Player.GetOneMinusSusPercentage();
    }
}
