using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Level : MonoBehaviour
{
    public int profitMade;
    public Requirements reqs;
    public Achievements achieve;
    public abstract int Algorithm();
    public abstract void Results();
}
