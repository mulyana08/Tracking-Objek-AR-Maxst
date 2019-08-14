using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_False : MonoBehaviour
{
    public GameObject Objek3D;

    private void Awake()
    {
        Objek3D.gameObject.SetActive(false);
    }
}
