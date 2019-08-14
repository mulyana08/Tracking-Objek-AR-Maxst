using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public AudioSource ButtonSound;
    public string NamaScene;

    public void PindahKeScene()
    {
        AudioSource buttonsound = ButtonSound.GetComponent<AudioSource>();
        buttonsound.PlayOneShot(buttonsound.clip);

        Scene SceneIni = SceneManager.GetActiveScene();
        if (SceneIni.name != NamaScene)
            SceneManager.LoadScene(NamaScene);
    }

    public void Keluar()
    {
        ButtonSound.PlayOneShot(ButtonSound.clip);
        Application.Quit();
    }
}
