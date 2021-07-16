using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a LapObject.
/// </summary>
public class LapObject : TargetObject
{
    [Header("LapObject")] [Tooltip("Is this the first/last lap object?")]
    public bool finishLap;

    [HideInInspector] public bool lapOverNextPass;

    public List<ArcadeKart> kartsPassed = new List<ArcadeKart>();

    void Start()
    {
        Register();
    }

    void OnEnable()
    {
        lapOverNextPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player")))
            return;

        var kart = other.transform.parent.GetComponentInChildren<ArcadeKart>();
        Objective.OnUnregisterPickup?.Invoke(this, kart);
    }
}
