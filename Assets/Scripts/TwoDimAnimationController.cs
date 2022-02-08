using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimAnimationController : MonoBehaviour
{
    public static TwoDimAnimationController Instance;

    [Header ("Animation Tabs")]

    public Animator animator;

    public float acceleration = 2f;

    private bool isRunning => PlayerController.Instance.isRunning;

    private void Awake()
    {
        Instance = this;
    }

    public void SetAnimation(string animName, bool value)
    {
        animator.SetBool(animName, value);
    }

    public void SetAnimation(string animName, float input)
    {
        animator.SetFloat(animName, Mathf.Lerp(animator.GetFloat(animName), input, Time.deltaTime * acceleration));
    }

    public void ClampingAnim(float inputX, float inputY)
    {
        inputX = Mathf.Clamp(inputX, isRunning ? -1f : -0.5f, isRunning ? 1f : 0.5f);
        inputY = Mathf.Clamp(inputY, isRunning ? -1f : -0.5f, isRunning ? 1f : 0.5f);
    }
}
