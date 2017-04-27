using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Books
    {

        string Author;
        string Title;
        string Status;
        public string BAuthor
        {
            get
            {
                return Author;
            }
            set
            {
                Author = value;
            }
        }
        public string BTitle
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }
        public string BStatus
        {
            get
            {
                return Status;
            }
            set
            {
                Status = value;
            }
        }
        public Books()
        {
        }
        public Books(string inputAuthor, string inputTitle, string inputStatus)
        {
            BAuthor = inputAuthor;
            BTitle = inputTitle;
            BStatus = inputStatus;
        }
    }
}