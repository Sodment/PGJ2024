using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyFOV))]
public class EnemyInteraction : MonoBehaviour
{
    //Powiedzmy �e kiedy przeciwnik jest do�� blisko (dajmy 2) to jest losowanko od -40 do 20
    //Wszystko poni�ej 0 to random przechodz�cy na ulicy
    //Wszystko powy�ej 0 to jaki� znajomek kt�ry chce pogada�

    [SerializeField] Image meetingRemain;
    [SerializeField] GameObject barObject;

    bool isChecked = false;

    private void Start()
    {
        if (meetingRemain == null) { Debug.LogError("Missing attach: meetingRamain"); }
        if (barObject == null) { Debug.LogError("Missing attach: barObject"); }

        barObject.SetActive(false);
    }

    public void ResetMeetChecking()
    {
        isChecked = false;
    }

    public void CheckMeeting()
    {
        if (!isChecked)
        {
            Debug.Log("Check for meeting");
            float roll = Random.Range(-40.0f, 20.0f);
            if (roll < 0) { return; }
            else
            {
                Player.StartInteraction(roll);
                StartCoroutine(Meeting(roll));
            }
            isChecked = true;
        }
    }

    IEnumerator Meeting(float timeRemain)
    {
        barObject.SetActive (true);
        float totalTime = timeRemain;
        while (timeRemain > 0)
        {
            timeRemain-=Time.deltaTime;
            meetingRemain.fillAmount = timeRemain / totalTime;
            yield return null;
        }
        barObject.SetActive (false);
        Player.EndInteraction();
    }
}
