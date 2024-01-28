using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    const int ENEMY_BEHIND_PLAYER = 2;
    List<GameObject> enemys = new List<GameObject>();
    Transform player;
    int currentIndex = 0;
    Vector3 lastSpawnPos = new Vector3(5f, 1.75f, 20f);
    Vector3 forward = Vector3.forward;
    Vector3 right = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        foreach(Transform k in transform)
        {
            enemys.Add(k.gameObject);
        }

        foreach (GameObject k in enemys)
        {
            lastSpawnPos += forward * Random.Range(15.0f, 45.0f);
            k.transform.position = lastSpawnPos + right * Random.Range(-0.5f, 0.5f);
        }
    }


    void Update()
    {
        int checkingIndex = (currentIndex + enemys.Count + ENEMY_BEHIND_PLAYER)% enemys.Count;
        if (player.position.z > enemys[checkingIndex].transform.position.z)
        {
            lastSpawnPos += forward * Random.Range(15.0f, 45.0f);
            enemys[currentIndex].transform.position = lastSpawnPos + right * Random.Range(-0.5f, 0.5f);
            enemys[currentIndex].GetComponent<EnemyInteraction>().ResetMeetChecking();
            currentIndex = (currentIndex+1)%enemys.Count;
        }
    }
}
