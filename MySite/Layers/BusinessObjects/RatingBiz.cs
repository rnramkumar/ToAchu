using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
   public class RatingBiz
    {
        string reviewTitle;
        string reviewText;
        string reviewerName;
        string reviewDate;
        string reviewStatus;
        decimal rating;
        int pid;
        int totalRating;

        public int TotalRating
        {
            get { return totalRating; }
            set { totalRating = value; }
        }

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public decimal Rating
        {
            get { return rating; }
            set { rating = value; }
        }

       public string ReviewTitle
       {
           get { return reviewTitle; }
           set { reviewTitle = value; }
       }
       public string ReviewText
       {
           get { return reviewText; }
           set { reviewText = value; }
       }
       public string ReviewerName
       {
           get { return reviewerName; }
           set { reviewerName = value; }
       }
       public string ReviewDate
       {
           get { return reviewDate; }
           set { reviewDate = value; }
       }
       public string ReviewStatus
       {
           get { return reviewStatus; }
           set { reviewStatus = value; }
       }




    }
}
