using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] int barrierId;

    public int GetBarrierId()
    {
        return barrierId;
    }
}
