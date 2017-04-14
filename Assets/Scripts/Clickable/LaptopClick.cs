using Assets.Scripts.Managers;
using Com.IsartDigital.BeTheBastard.Scripts.Email;
using UnityEngine;

namespace Assets.Scripts.Clickable
{

    /// <summary>
    /// 
    /// </summary>
    public class LaptopClick : MonoBehaviour
    {

        protected void Start()
        {

        }

        protected void Update()
        {

        }

        protected void OnMouseUp()
        {
            ClickableManager.manager.SetObjectName(tag);
        }

        public void ClickCloseMail()
        {
            GameObject.FindGameObjectWithTag("panelMail").SetActive(false);
        }

        public void ClickAnswer1()
        {
            MailBox.answerMail(MailBox.activeMail.id, 1);
            GameObject.FindGameObjectWithTag("panelMail").SetActive(false);
        }

        public void ClickAnswer2()
        {
            MailBox.answerMail(MailBox.activeMail.id, 2);
            GameObject.FindGameObjectWithTag("panelMail").SetActive(false);
        }
    }
}