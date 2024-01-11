using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public int currentPage;
    public int role;
    [SerializeField] private SelectRole scriptSelectRole;
    [SerializeField] private SelectWeapons scriptSelectWeapons;
    [SerializeField] private GameObject[] screenCanvas;
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
                screenCanvas[0].SetActive(true);
                break;
        }

        currentPage -= 1;
    }

    public void ShowWeapons()
    {
        screenCanvas[1].SetActive(true);
        scriptSelectWeapons.ShowWeapons();
        animatorBack.SetBool("isShow", true);
        buttonBack.interactable = true;
    }

    public void DisableCanvas(int index)
    {
        screenCanvas[index].SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
