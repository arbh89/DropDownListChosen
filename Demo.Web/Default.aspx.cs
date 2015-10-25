using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var type = typeof(System.Web.UI.Control);
                var types = AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));
                ddlTest.DataSource = types;
                ddlTest.DataTextField = "Name";
                ddlTest.DataValueField = "FullName";
                ddlTest.DataBind();

                Dropdownlist1.DataSource = types;
                Dropdownlist1.DataTextField = "Name";
                Dropdownlist1.DataValueField = "FullName";
                Dropdownlist1.DataBind();
            }
        }
    }
}