using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class btn_GameObjek : MonoBehaviour
{
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    int counter;

    public GameObject btn_Objek;
    public AudioSource ButtonSound;

    // Use this for initialization
    void Start()
    {
        definedButton = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Debug.Log("Button Clicked");
                OnClick.Invoke();
                ButtonSound.PlayOneShot(ButtonSound.clip);
                counter++;
                if (counter % 2 == 1)
                {
                    btn_Objek.gameObject.SetActive(true);
                }
                else
                {
                    btn_Objek.gameObject.SetActive(false);
                }
                
            }
        }
    }
}
