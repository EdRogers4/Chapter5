using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Select scriptSelect;

    public void StopRotation()
    {
        gameObject.GetComponent<Rotation>().enabled = false;
    }

    public void ToggleIntroOff()
    {
        scriptSelect.isIntro = false;
    }
}
