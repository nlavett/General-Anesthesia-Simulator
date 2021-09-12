using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    [Tooltip("Animator")]
    public Animator animator;
    [Tooltip("Delta value used to modify the speed of animation")]
    public float AnimationDelta;
    private float gripTarget;
    private float triggerTarget;
    private float currentGripPoint;
    private float currentTriggerPoint;
    private float pressTarget;
    private float currentPressPoint;

    private string gripAnimationParameter = "Hold";
    private string triggerAnimationParameter = "UseHeld";
    private string pressAnimationParameter = "Press";
    public UnityAction grab;
    // Start is called before the first frame update
    void Start()
    {
        //animator = this.GetComponent<Animator>(); Only necessary if not assigned in inspector
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    public void SetGrip(float gripInput)
    {
        gripTarget = gripInput;
    }

    public void SetTrigger(float triggerInput)
    {
        triggerTarget = triggerInput;
    }

    public void SetPress(float pressInput)
    {
        pressTarget = pressInput;
    }

    public void AnimateHand()
    {
        if (currentGripPoint != gripTarget)
        {
            AnimateHold();
            Debug.Log($"CurrentGripPoint: {currentGripPoint}");
        }
        if (currentTriggerPoint != triggerTarget)
        {
            AnimateUse();
        }
        if (currentPressPoint != pressTarget)
        {
            AnimatePress();
        }
    }
    
    public void AnimateHold()
    {
        currentGripPoint = Mathf.MoveTowards(currentGripPoint, gripTarget, Time.time * AnimationDelta);
        animator.SetFloat(gripAnimationParameter, currentGripPoint);
    }
    public void AnimatePress()
    {
        currentPressPoint = Mathf.MoveTowards(currentPressPoint, pressTarget, Time.time * AnimationDelta);
        animator.SetFloat(pressAnimationParameter, currentPressPoint);
    }

    public void AnimateUse()
    {
        currentTriggerPoint = Mathf.MoveTowards(currentTriggerPoint, triggerTarget, Time.time * AnimationDelta);
        animator.SetFloat(triggerAnimationParameter, currentTriggerPoint);
    }
}