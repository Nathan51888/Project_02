using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switch : MonoBehaviour
{
    public bool IsActivated;
    public abstract void TurnOn();
    public abstract void TurnOff();
}