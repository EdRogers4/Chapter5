using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRole : MonoBehaviour
{
    public bool isSelectRole;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isIntro;
    [SerializeField] private bool[] isSelected;
    [SerializeField] private Sprite[] spriteBanner;
    [SerializeField] private Image imageBanner;
    [SerializeField] private RectTransform transformBanner;
    [SerializeField] private RectTransform[] transformRole;
    [SerializeField] private RectTransform[] transformRoleTarget;
    [SerializeField] private RectTransform[] transformTargetBottom;
    [SerializeField] private RectTransform transformTargetSide;
    [SerializeField] private Vector3[] positionRoleOrigin;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animatorBanner;
    private RaycastHit hit;
    private int selectedPrevious;
    private int selectedCurrent;

    private void Start()
    {
        isSelectRole = true;

        for (int i = 0; i < positionRoleOrigin.Length; i++)
        {
            positionRoleOrigin[i] = transformRole[i].position;
        }
    }

    void Update()
    {
        
    }

    public void Select(int index)
    {
        selectedPrevious = selectedCurrent;
        isSelected[index] = true;
        selectedCurrent = index;
        imageBanner.sprite = spriteBanner[index];
        animatorBanner.SetBool("isStretch", false);
        audioSource.Stop();

        if (selectedPrevious != selectedCurrent)
        {
            isSelected[selectedPrevious] = false;
        }

        StartCoroutine(StretchBanner());
    }

    private IEnumerator StretchBanner()
    {
        yield return new WaitForSeconds(0.1f);
        animatorBanner.SetBool("isStretch", true);
        yield return new WaitForSeconds(0.5f);
        PlayMusic(selectedCurrent);
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = music[index];
        audioSource.Play();
    }
}
