using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_goToLink : MonoBehaviour
{
    public AudioSource ButtonSound;

    public void linkPetaMuseum()
    {
        ButtonSound.PlayOneShot(ButtonSound.clip);
        Application.OpenURL("https://www.google.com/maps/dir//Museum+Pusaka+Keraton+Kasepuhan+Cirebon,+Jl.+Kasepuhan+No.43,+Kesepuhan,+Kec.+Lemahwungkuk,+Kota+Cirebon,+Jawa+Barat+45114/@-6.7263338,108.5688174,17z/data=!4m8!4m7!1m0!1m5!1m1!1s0x2e6ee263eaaaaaab:0x20ea18cbfb1df195!2m2!1d108.5710061!2d-6.7263338");
    }

    public void linkLihatMuseum()
    {
        ButtonSound.PlayOneShot(ButtonSound.clip);
        Application.OpenURL("https://www.google.com/maps/place/Museum+Pusaka+Keraton+Kasepuhan+Cirebon/@-6.7263338,108.5710061,3a,75y,180h,90t/data=!3m8!1e1!3m6!1sAF1QipMDzxB5P5JkxtpAJtF_cSQG55CLS3x8zp0pMRWn!2e10!3e11!6shttps:%2F%2Flh5.googleusercontent.com%2Fp%2FAF1QipMDzxB5P5JkxtpAJtF_cSQG55CLS3x8zp0pMRWn%3Dw114-h120-k-no-pi-0-ya180-ro0-fo100!7i7200!8i3600!4m8!1m2!2m1!1sMuseum+Pusaka+Keraton+Kasepuhan+Cirebon+merupakan+museum!3m4!1s0x0:0x20ea18cbfb1df195!8m2!3d-6.7263338!4d108.5710064");
    }
}
