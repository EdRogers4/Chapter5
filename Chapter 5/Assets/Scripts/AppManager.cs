using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField] private int currentPage;
    public void Next()
    {
        currentPage += 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
