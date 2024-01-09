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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("Name: " + hit.transform.name);
            }
        }
    }

    public void ShowWeapons()
    {
        animatorWeapons.SetBool("isShow", true);
    }

    public void  HideWeapons()
    {
        animatorWeapons.SetBool("isShow", false);
    }

    public void EquipMain(int index)
    {
        slotMain.sprite = spriteMain[index];
    }
}
