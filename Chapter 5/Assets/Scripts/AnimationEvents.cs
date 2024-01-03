using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Select scriptSelect;
    [SerializeField] private Animator animator;

    public void StopRotation()
    {
        gameObject.GetComponent<Rotation>().enabled = false;
    }

    public void ToggleIntroOff()
    {
        scriptSelect.isIntro = false;
        animator.SetBool("isShow", false);
    }
}
