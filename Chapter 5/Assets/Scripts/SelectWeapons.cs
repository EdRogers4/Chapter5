using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapons : MonoBehaviour
{
    [SerializeField] private Animator animatorWeapons;
    [SerializeField] private Image slotMain;
    [SerializeField] private Image slotSide;
    [SerializeField] private Image slotMelee;
    [SerializeField] private Button[] buttonWeaponMain;
    [SerializeField] private Button[] buttonWeaponSide;
    [SerializeField] private Button[] buttonWeaponMelee;
    [SerializeField] private Sprite[] spriteMain;
    [SerializeField] private Sprite[] spriteSide;
    [SerializeField] private Sprite[] spriteMelee;

    public void ShowWeapons()
    {
        animatorWeapons.SetBool("isShow", true);
    }

    public void EquipMain(int index)
    {
        slotMain.sprite = spriteMain[index];
    }
}
