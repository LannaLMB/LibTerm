using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{

    // Declare as Abstract Class for Status Values
    abstract class AbstractStatus
    {
        // Will Tell User if Book is Checked Out or Not
        public abstract StatusValues GetStatus();

    }
}
