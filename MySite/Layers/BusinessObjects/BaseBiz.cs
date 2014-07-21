using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
   public class BaseBiz
    {
        int id;
        String name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
      

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
