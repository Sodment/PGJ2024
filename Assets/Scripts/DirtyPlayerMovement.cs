using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyPlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    const float BASE_SPEED = 10;
    float speed;

    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Player.OnInteractionStarted.AddListener(StopForInteraction);
        Player.OnInteractionStarted.AddListener(SetIdleAnimationState);
        Player.OnInteractionEnded.AddListener(EndInteraction);
        Player.OnInteractionEnded.AddListener(SetRunningAnimationState);
        speed = BASE_SPEED;
    }

    void SetIdleAnimationState()
    {
        playerAnimator.SetBool("Standing", true);
    }

    void SetRunningAnimationState()
    {
        playerAnimator.SetBool("Standing", false);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.forward * speed;
    }

    void StopForInteraction(float time)
    {
        rigidbody.velocity = Vector3.zero;
        speed = 0;
    }

    void EndInteraction()
    {
        speed = BASE_SPEED;
        rigidbody.velocity = Vector3.forward * speed;
    }
}
