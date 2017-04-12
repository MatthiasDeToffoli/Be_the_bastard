using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MailButton : MonoBehaviour {

    public void getMails()
    {
        MailBox.loadJson();
    }
}
