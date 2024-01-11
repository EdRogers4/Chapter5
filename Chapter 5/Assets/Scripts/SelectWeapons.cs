using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectWeapons : MonoBehaviour
{
    [SerializeField] private AppManager scriptAppManager;
    [SerializeField] private Animator animatorWeapons;
    [SerializeField] private Image slotMain;
    [SerializeField] private Image slotSide;
    [SerializeField] private Image slotMelee;
    [SerializeField] private Image[] slotBorder;
    [SerializeField] private Button[] buttonWeaponMain;
    [SerializeField] private Button[] buttonWeaponSide;
    [SerializeField] private Button[] buttonWeaponMelee;
    [SerializeField] private Sprite[] spriteMain;
    [SerializeField] private Sprite[] spriteSide;
    [SerializeField] private Sprite[] spriteMelee;
    [SerializeField] private Sprite[] spriteBorder;
    [SerializeField] private TextMeshProUGUI textNameMain;
    [SerializeField] private TextMeshProUGUI textNameSide;
    [SerializeField] private TextMeshProUGUI textNameMelee;
    [SerializeField] private string[] stringNameMain;
    [SerializeField] private string[] stringNameSide;
    [SerializeField] private string[] stringNameMelee;

    public void ShowWeapons()
    {
        animatorWeapons.SetBool("isShow", true);

        for (int i = 0; i < slotBorder.Length; i++)
        {
            slotBorder[i].sprite = spriteBorder[scriptAppManager.role];
        }
    }

    public void  HideWeapons()
    {
        animatorWeapons.SetBool("isShow", false);
    }

    public void EquipMain(int index)
    {
        slotMain.sprite = spriteMain[index];
        textNameMain.text = stringNameMain[index];
    }

    public void EquipSide(int index)
    {
        slotSide.sprite = spriteSide[index];
        textNameSide.text = stringNameSide[index];
    }

    public void EquipMelee(int index)
    {
        slotMelee.sprite = spriteMelee[index];
        textNameMelee.text = stringNameMelee[index];
    }
}
