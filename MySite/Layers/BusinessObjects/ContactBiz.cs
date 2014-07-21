using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class ContactBiz
    {
        int contactId;

        string contactName = string.Empty;
        string email = string.Empty;
        string subject = string.Empty;
        string comments = string.Empty;
        string feedbackType = string.Empty;

        Boolean isContact;

        public string FeedbackType
        {
            get { return feedbackType; }
            set { feedbackType = value; }
        }

        public Boolean IsContact
        {
            get { return isContact; }
            set { isContact = value; }
        }

        public int ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        } 


    }
}
