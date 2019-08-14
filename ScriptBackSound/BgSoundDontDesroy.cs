using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundDontDesroy : MonoBehaviour
{
    public static BgSoundDontDesroy obyek = null;
    void Awake()
    {
        if (obyek == null)
            obyek = this;
        else if (obyek != null)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
