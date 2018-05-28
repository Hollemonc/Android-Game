using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Win : MonoBehaviour {

    public Text WinText;
    public Button RestartButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }
}
