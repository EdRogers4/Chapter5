using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private AppManager scriptAppManager;
    [SerializeField] private Select scriptSelect;
    [SerializeField] private SelectRole scriptSelectRole;
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

    public void NextButton()
    {
        scriptSelectRole.ToggleNextButtonOn();
    }

    public void ToggleRoleButtonsOn()
    {
        scriptSelectRole.ToggleRoleButtons(true);
    }

    public void ToggleRoleButtonsOff()
    {
        scriptSelectRole.ToggleRoleButtons(false);
    }

    public void ShowWeapons()
    {
        scriptAppManager.ShowWeapons();
    }
}
