using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyFOV))]
public class EnemyInteraction : MonoBehaviour
{
    //Powiedzmy ¿e kiedy przeciwnik jest doœæ blisko (dajmy 2) to jest losowanko od -40 do 20
    //Wszystko poni¿ej 0 to random przechodz¹cy na ulicy
    //Wszystko powy¿ej 0 to jakiœ znajomek który chce pogadaæ

    [SerializeField] Image meetingRemain;
    [SerializeField] GameObject barObject;
    [SerializeField] Transform smile;

    Vector3 smileLocalPos;
    bool isChecked = false;

    private void Start()
    {
        if (meetingRemain == null) { Debug.LogError("Missing attach: meetingRamain"); }
        if (barObject == null) { Debug.LogError("Missing attach: barObject"); }

        smileLocalPos = smile.localPosition;
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
            float roll = Random.Range(-40.0f, 10.0f);
            //float roll = Random.Range(0.0f, 10.0f);
            if (roll < 0) 
            { 
                isChecked= true; 
                return; 
            }
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
            smile.localPosition = smileLocalPos + Vector3.up * Random.Range(-0.05f, 0.05f);
            yield return null;
        }
        barObject.SetActive (false);
        Player.EndInteraction();
    }
}
