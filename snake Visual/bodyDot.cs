using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_Visual
{
    class bodyDot : Panel
    {
        public bodyDot()
        {

        }
       
        public bodyDot(Point location,Size size)
        {
            this.Location = location;
            this.Size = size;

        }
    }
}
