using mvreylib.features.messenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvreylibManager : MonoBehaviour
{
    public static MvreylibManager instance;

    public static MvreylibManager Instance() { return instance; }

    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);

        instance = this;

        Messenger.Init();
    }
}