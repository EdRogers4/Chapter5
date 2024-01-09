using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public int currentPage;
    [SerializeField] private SelectRole scriptSelectRole;
    [SerializeField] private SelectWeapons scriptSelectWeapons;
    [SerializeField] private Animator animatorNext;
    [SerializeField] private Animator animatorBack;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonBack;

    public void Next()
    {
        animatorNext.SetBool("isShow", false);
        buttonNext.interactable = false;

        switch (currentPage)
        {
            case 0:
                scriptSelectRole.NextPage();
                break;
        }

        currentPage += 1;
        buttonNext.interactable = false;
    }

    public void Back()
    {
        animatorBack.SetBool("isShow", false);
        buttonBack.interactable = false;

        switch (currentPage)
        {
            case 1:
                scriptSelectWeapons.HideWeapons();
                break;
        }

        currentPage -= 1;
    }

    public void ShowWeapons()
    {
        scriptSelectWeapons.ShowWeapons();
        animatorBack.SetBool("isShow", true);
        buttonBack.interactable = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
