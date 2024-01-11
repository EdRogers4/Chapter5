using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectAnimal : MonoBehaviour
{
    [SerializeField] private AppManager scriptAppManager;
    [SerializeField] private bool[] isInfoFilled;
    [SerializeField] private Image imageIconBackground;
    [SerializeField] private Image imageAnimal;
    [SerializeField] private Image imageColor;
    [SerializeField] private Button[] buttonIcon;
    [SerializeField] private Sprite[] spriteAnimal;
    [SerializeField] private Sprite[] spriteAnimalWhite;
    [SerializeField] private Sprite[] spriteRole;
    [SerializeField] private Sprite[] spriteButtonColor;
    [SerializeField] private TextMeshProUGUI textInputName;
    [SerializeField] private Animator animatorAnimals;
    private int indexRole;
    private bool isSelectAnimal;
    private bool isSelectColor;
    private bool isNextButtonOn;

    public void ShowAnimals()
    {
        animatorAnimals.SetBool("isShow", true);
    }

    public void HideAnimals()
    {
        animatorAnimals.SetBool("isShow", false);
    }

    public void SelectColor(int index)
    {
        isSelectColor = true;
        indexRole = index;
        imageColor.sprite = spriteRole[index];
        isInfoFilled[1] = true;

        if (isSelectAnimal)
        {
            imageIconBackground.sprite = spriteButtonColor[index];
        }

        CheckInfoFilled();
    }

    public void SelectIcon(int index)
    {
        isSelectAnimal = true;
        imageAnimal.sprite = spriteAnimalWhite[index];
        isInfoFilled[2] = true;
        CheckInfoFilled();

        if (isSelectColor)
        {
            imageIconBackground.sprite = spriteButtonColor[indexRole];
        }
    }

    public void CheckInputName()
    {
        if (textInputName.text.Length >= 2 && !isInfoFilled[0] && !isNextButtonOn)
        {
            isInfoFilled[0] = true;
            CheckInfoFilled();
        }
        else if (textInputName.text.Length < 2)
        {
            isInfoFilled[0] = false;

            if (isNextButtonOn)
            {
                scriptAppManager.ToggleNextButtonOff();
            }
        }
    }

    private void CheckInfoFilled()
    {
        for (int i = 0; i < isInfoFilled.Length; i++)
        {
            if (!isInfoFilled[i])
            {
                return;
            }
        }

        scriptAppManager.ToggleNextButtonOn();
        isNextButtonOn = true;
    }

}
