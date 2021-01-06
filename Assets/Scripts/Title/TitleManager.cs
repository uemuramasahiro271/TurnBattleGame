using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void OnButtonClick()
    {
        SountdManager.instance.PlaySE(0);
    }
}
