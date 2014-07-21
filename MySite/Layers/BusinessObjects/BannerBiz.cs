using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class BannerBiz
    {
        int adId;
        int trackId;
        int width;
        int height;
        int weightage;
        int hitCount;

        string category;
        string advName;
        string imgPath;
        string redirectURL;
        string altText;
        string ipAddress;
        string userAction;

        DateTime startDate;
        DateTime endDate;

        bool active;

        public int HitCount
        {
            get { return hitCount; }
            set { hitCount = value; }
        }


        public string UserAction
        {
            get { return userAction; }
            set { userAction = value; }
        }

    
        public int AdId
        {
            get { return adId; }
            set { adId = value; }
        }
        
        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }
        
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        
         public int Weightage
        {
            get { return weightage; }
            set { weightage = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        
        public string AdvName
        {
            get { return advName; }
            set { advName = value; }
        }

        public string ImgPath
        {
            get { return imgPath; }
            set { imgPath = value; }
        }
        
        public string RedirectURL
        {
            get { return redirectURL; }
            set { redirectURL = value; }
        }

        public string AltText
        {
            get { return altText; }
            set { altText = value; }
        }

        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

    }
}
