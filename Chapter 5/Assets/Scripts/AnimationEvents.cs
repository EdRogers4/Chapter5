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
        scriptAppManager.ToggleNextButtonOn();
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

    public void OnHideWeapons()
    {
        if (scriptAppManager.currentPage == 0)
        {
            scriptSelectRole.ShowButtons();
        }
        else if (scriptAppManager.currentPage == 2)
        {
            scriptAppManager.EnableCanvas(2);
        }
    }

    public void DisableRolesCanvas()
    {
        scriptAppManager.DisableCanvas(0);
    }

    public void DisableWeaponsCanvas()
    {
        scriptAppManager.DisableCanvas(1);
    }
}
