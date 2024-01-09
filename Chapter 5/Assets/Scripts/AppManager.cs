using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField] private SelectRole scriptSelectRole;
    [SerializeField] private int currentPage;
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

    public void Quit()
    {
        Application.Quit();
    }
}
