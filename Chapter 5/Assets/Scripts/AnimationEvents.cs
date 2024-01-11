using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private AppManager scriptAppManager;
    [SerializeField] private Select scriptSelect;
    [SerializeField] private SelectRole scriptSelectRole;
    [SerializeField] private SelectWeapons scriptSelectWeapons;
    [SerializeField] private SelectAnimal scriptSelectAnimal;
    [SerializeField] private Animator animator;

    public void StopRotation()
    {
        gameObject.GetComponent<Rotation>().enabled = false;
    }

    public void ToggleIntroOff()
    {
        scriptSelect.isIntro = false;
        animator.SetBool("isShow", false);
        scriptAppManager.EnableMysteriesObjects();
    }

    public void NextButton()
    {
        scriptAppManager.ToggleNextButtonOn();
    }

    public void BackButton()
    {
        scriptAppManager.ToggleBackButtonOn();
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
            scriptAppManager.ShowAnimals();
        }
    }

    public void OnHideAnimals()
    {
        scriptAppManager.DisableCanvas(2);

        if (scriptAppManager.currentPage == 1)
        {
            scriptAppManager.EnableCanvas(1);
            scriptAppManager.ShowWeapons();
        }
        else if (scriptAppManager.currentPage == 3)
        {
            scriptAppManager.EnableCanvas(3);
            scriptAppManager.ShowMysteries();
        }
    }

    public void PlayMysteriesIntroMusic()
    {
        scriptSelect.PlayIntroMusic();
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
