using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace DropDownListChosen
{
    internal class Common
    {
        public static Control FindControlReqursive(string controlId, Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                Control result = FindControlReqursive(controlId, control);
                if (result != null)
                {
                    return result;
                }
            }
            return parent.FindControl(controlId);
        }

        public static bool FindControlParent(Control control, Type type)
        {
            Control ctrlParent = control;
            while ((ctrlParent = ctrlParent.Parent) != null)
            {
                if (ctrlParent.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }
    }
}