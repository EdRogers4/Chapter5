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
    [SerializeField] private SelectAnimal scriptSelectAnimal;
    [SerializeField] private Select scriptSelect; //SelectMysteries
    [SerializeField] private GameObject[] screenCanvas;
    [SerializeField] private GameObject mysteries;
    [SerializeField] private Animator animatorNext;
    [SerializeField] private Animator animatorBack;
    [SerializeField] private Animator animatorMysteriesIntro;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonBack;
    [SerializeField] private AudioSource audioMusic;
    private bool isFadeOutMusic;

    private void FixedUpdate()
    {
        if (isFadeOutMusic && audioMusic.volume > 0f)
        {
            audioMusic.volume -= 0.01f;
        }
    }

    public void Next()
    {
        animatorNext.SetBool("isShow", false);
        animatorBack.SetBool("isShow", false);
        buttonNext.interactable = false;
        buttonBack.interactable = false;

        switch (currentPage)
        {
            case 0:
                scriptSelectRole.NextPage();
                break;
            case 1:
                scriptSelectWeapons.HideWeapons();
                break;
            case 2:
                scriptSelectAnimal.HideAnimals();
                break;
        }

        currentPage += 1;
        buttonNext.interactable = false;
    }

    public void Back()
    {
        animatorBack.SetBool("isShow", false);
        animatorNext.SetBool("isShow", false);
        buttonNext.interactable = false;
        buttonBack.interactable = false;

        switch (currentPage)
        {
            case 1:
                scriptSelectWeapons.HideWeapons();
                screenCanvas[0].SetActive(true);
                currentPage -= 1;
                break;
            case 2:
                scriptSelectAnimal.HideAnimals();
                screenCanvas[1].SetActive(true);
                currentPage -= 1;
                break;
            case 3:
                scriptSelect.Back();
                break;
        }
    }

    public void ToggleBackButtonOn()
    {
        animatorBack.SetBool("isShow", true);
        buttonBack.interactable = true;
    }

    public void ToggleNextButtonOn()
    {
        animatorNext.SetBool("isShow", true);
        buttonNext.interactable = true;

        if (currentPage > 0)
        {
            animatorBack.SetBool("isShow", true);
            buttonBack.interactable = true;
        }
    }

    public void ToggleNextButtonOff()
    {
        animatorNext.SetBool("isShow", false);
        buttonNext.interactable = false;
    }

    public void ShowWeapons()
    {
        screenCanvas[1].SetActive(true);
        scriptSelectWeapons.ShowWeapons();
        buttonBack.interactable = true;
    }

    public void ShowAnimals()
    {
        scriptSelectAnimal.ShowAnimals();
    }

    public void ShowMysteries()
    {
        isFadeOutMusic = true;
        scriptSelect.ShowMysteryIntro();
    }

    public void EnableMysteriesObjects()
    {
        mysteries.SetActive(true);
    }

    public void DisableCanvas(int index)
    {
        screenCanvas[index].SetActive(false);
    }

    public void EnableCanvas(int index)
    {
        screenCanvas[index].SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
