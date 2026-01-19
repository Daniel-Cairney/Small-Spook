using System;
using UnityEngine;

public class GhostSpotter : MonoBehaviour
{
    private void OnEnable()
    {
        LanternLogic.GhostPing += GhostLocate;
    }

    private void GhostLocate()
    {
        Debug.Log("im getting called hoe");
    }
}
