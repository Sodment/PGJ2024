using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFOV : MonoBehaviour
{
    //Where enemy in spherecast, look at it
    public Transform player;
    //How far enemy can see
    public float maxDistance = 10f;
    public float meetingDistance = 8f;


    public Transform enemyEye;
    public Transform playerRaycastHitStarter;

    public UnityEvent OnSee;

    public Transform defaultEyeGaze;

    EnemyInteraction myInteraction;

    private void Start()
    {
        myInteraction = GetComponent<EnemyInteraction>();
        OnSee = new UnityEvent();
        OnSee.AddListener(GameManager.instance.EnemySeePlayer);
    }

    private void FixedUpdate()
    {
        //If player is in range, look at it
        if (DetectPlayerObjectIfInRange() != null)
        {
            player = DetectPlayerObjectIfInRange().transform;
            float dist = (Vector3.Distance(transform.position, player.transform.position));
            if(dist < meetingDistance)
            {
                Debug.Log("InMeetingRange");
                myInteraction.CheckMeeting();
            }
            enemyEye.LookAt(player);
            OnSee.Invoke();
        }
        else
        {
            enemyEye.LookAt(defaultEyeGaze);
        }
    }

    GameObject DetectPlayerObjectIfInRange()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, maxDistance, transform.forward, maxDistance);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                //Debug.LogFormat("Hit {0}", hits[i].collider.gameObject.name);
                if (hits[i].collider.gameObject.tag != "Player") continue;
                RaycastHit hit;
                if (Physics.Raycast(playerRaycastHitStarter.position, (hits[i].collider.gameObject.transform.position - playerRaycastHitStarter.position).normalized, out hit, Mathf.Infinity))
                {
                    if(hit.collider.gameObject.tag != "Player") continue;
                    Debug.DrawRay(playerRaycastHitStarter.position, (hits[i].collider.gameObject.transform.position - playerRaycastHitStarter.position).normalized * hit.distance, Color.yellow);
                    //Debug.Log("Did Hit");
                    hits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                    return hits[i].collider.gameObject;
                }
                return null;
                
            }
        }
        return null;
    }



}
