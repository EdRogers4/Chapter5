using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] private SelectRole scriptSelectRole;
    [SerializeField] private SelectWeapons scriptSelectWeapons;
    [SerializeField] private int currentPage;
    [SerializeField] private Animator animatorBack;
    [SerializeField] private Button buttonBack;

    public void Next()
    {
        switch (currentPage)
        {
            case 0:
                scriptSelectRole.NextPage();
                break;
        }

        //currentPage += 1;
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
