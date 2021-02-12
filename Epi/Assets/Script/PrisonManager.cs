using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonManager : MonoBehaviour
{
    #region Singleton

    public static PrisonManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    public GameObject prison;


}
