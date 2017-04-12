using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

/// <summary>
/// Type definition for mails
/// </summary>
public struct Mail {
    public int id;
    public string expediteur;
    public bool isRead;
    public bool answered;
    public string message;
    public int answerId;
    public string answer1;
    public string answer2;
    public string answer3;

    public Mail(string pMessage, string pExpe, int pId, List<string> answers)
    {
        this.id = pId;
        this.expediteur = pExpe;
        this.isRead = false;
        this.answered = false;
        this.message = pMessage;
        this.answerId = 0;
        this.answer1 = answers[0];
        this.answer2 = answers[1];
        this.answer3 = answers[2];
    }
}

namespace Com.IsartDigital.BeTheBastard.Scripts.Email
{
    public class MailBox
    {
        // contains all mail (read or not)
        public static Dictionary<int, Mail> mailList = new Dictionary<int, Mail>();

        /// <summary>
        /// Add a new mail in the mailBox
        /// </summary>
        protected static void newMail(string pMessage, string pExpe, List<string> answers)
        {
            Mail lNewMail = new Mail(pMessage, pExpe, getNewKey(), answers);
            mailList.Add(lNewMail.id, lNewMail);
        }

        // valid the answer
        public static void answerMail(int idMail, int idRep)
        {
            Mail lMail = mailList[idMail];
            lMail.isRead = true;
            lMail.answered = true;
            lMail.answerId = idRep;
            mailList[idMail] = lMail;
        }

        // open the mail
        public static void readMail(int idMail)
        {
            Mail lMail = mailList[idMail];
            lMail.isRead = true;
            mailList[idMail] = lMail;
        }

        // get json, read and create mails
        public static void loadJson()
        {
            string json = File.ReadAllText(Application.dataPath + "/Scripts/mails.json");
            JsonData jsonMails = JsonMapper.ToObject(json);

            int nbMail = jsonMails.Count;
            for (int i = 0; i < nbMail; i++)
            {
                newMail(
                    jsonMails[i]["txt"].ToString(), 
                    jsonMails[i]["exp"].ToString(), 
                    new List<string> {
                        jsonMails[i]["rep"][0].ToString(),
                        jsonMails[i]["rep"][1].ToString(),
                        jsonMails[i]["rep"][2].ToString()
                    });
            }
        }

        protected static int getNewKey() { return mailList.Count + 1; }
    }
}
