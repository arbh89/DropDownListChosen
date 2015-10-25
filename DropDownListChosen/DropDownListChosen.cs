using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("DropDownListChosen", "ucc")]
[assembly: WebResource("DropDownListChosen.css.chosen.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("DropDownListChosen.css.chosen-sprite.png", "image/png")]

namespace DropDownListChosen
{
    [ToolboxData(@"<{0}:DropDownListChosen runat=""server"" ></{0}:DropDownListChosen>"),
    ToolboxBitmapAttribute(typeof(DropDownListChosen), "DropDownListChosen.dropdown.ico")]
    public class DropDownListChosen : System.Web.UI.WebControls.DropDownList
    {
        // ####################

        #region Local Variables

        private string sCssClass = "chzn-select";

        #endregion Local Variables

        // ###################

        #region Public Properties

        //Chosen automatically sets the default field text ("Choose a country...") by reading the select element's data-placeholder value. If no data-placeholder value is present, it will default to "Select an Option" or "Select Some Options" depending on whether the select is single or multiple. You can change these elements in the plugin js file as you see fit.
        [Description("Set the text as watermark")]
        [Category("Appearence")]
        [Browsable(true)]
        [Themeable(true)]
        [DefaultValue("Choose an option")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DataPlaceHolder
        {
            get
            {
                object o = ViewState["DataPlaceholder"];
                if (o == null)
                    return string.Empty; ;
                return (string)o;
            }
            set { ViewState["DataPlaceholder"] = value; }
        }

        [Description("Set the Message when no results")]
        [Category("Behavior")]
        [Browsable(true)]
        [Themeable(true)]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NoResultsText
        {
            get
            {
                object o = ViewState["NoResultsText"];
                if (o == null)
                    return string.Empty; ;
                return (string)o;
            }
            set { ViewState["NoResultsText"] = value; }
        }

        [Description("When a single select box isnt a required field, you can set this option to true and Chosen will add a UI element for option deselection. This will only work if the first option has blank text.")]
        [Category("Behavior")]
        [Browsable(true)]
        [Themeable(true)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowSingleDeselect
        {
            get
            {
                object o = ViewState["AllowSingleDeselect"];
                if (o == null)
                {
                    ViewState["AllowSingleDeselect"] = true;
                    o = ViewState["AllowSingleDeselect"];
                }
                return (bool)o;
            }
            set { ViewState["AllowSingleDeselect"] = value; }
        }

        [Description("The option can be specified to hide the search input on single selects if there are fewer than (n) options.")]
        [Category("Behavior")]
        [Browsable(true)]
        [Themeable(true)]
        [DefaultValue(5)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int DisableSearchThreshold
        {
            get
            {
                object o = ViewState["DisableSearchThreshold"];
                if (o == null)
                {
                    ViewState["DisableSearchThreshold"] = 10;
                    o = ViewState["DisableSearchThreshold"];
                }
                return (int)o;
            }
            set { ViewState["DisableSearchThreshold"] = value; }
        }

        [Description("Supports right to left select boxes.")]
        [Category("Behavior")]
        [Browsable(true)]
        [Themeable(true)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RightToLeft
        {
            get
            {
                object o = ViewState["RightToLeft"];
                if (o == null)
                    return false;
                return (bool)o;
            }
            set { ViewState["RightToLeft"] = value; }
        }

        #endregion Public Properties

        // ###################

        #region Control Init

        /// <summary>
        /// Initialize this control. We need to call RegisterRequiresPostBack
        /// </summary>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string css = "<link href=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "DropDownListChosen.css.chosen.css") + "\" type=\"text/css\" rel=\"stylesheet\" />";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "cssFile", css, false);
            Page.RegisterRequiresPostBack(this);
        }

        #endregion Control Init

        // ###################

        #region Render

        /// <summary>
        /// Override the Render Event
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            string script = string.Empty;
            ScriptManager stm = ScriptManager.GetCurrent(this.Page);

            if (Common.FindControlParent(this, typeof(UpdatePanel)) && stm.IsInAsyncPostBack)
            {
                script = string.Format(@"
                                var prm_{0} = Sys.WebForms.PageRequestManager.getInstance();
                                prm_{0}.add_pageLoaded(init);
                                function init(){{ window.setTimeout('dropDownChosen_{0}()',100); }}
                                function dropDownChosen_{0}() {{
                                $('#{0}').chosen( {{
                                  allow_single_deselect: {1},
                                  disable_search_threshold: {2},
                                  no_results_text: '{3}',
                                  width : '{4}'
                               }}
                               );
                            }};", this.ClientID, AllowSingleDeselect.ToString().ToLower(), DisableSearchThreshold, NoResultsText, this.Width);
            }
            else
            {
                script = string.Format(@"
                            $(document).ready(function () {{
                                $('#{0}').chosen( {{
                                  allow_single_deselect: {1},
                                  disable_search_threshold: {2},
                                  no_results_text: '{3}',
                                  width : '{4}'
                               }}
                               );
                            }});", this.ClientID, AllowSingleDeselect.ToString().ToLower(), DisableSearchThreshold, NoResultsText, this.Width);
            }

            this.AddCssClass(this.CssClass);

            if (RightToLeft)
            {
                this.AddCssClass("chzn-rtl");
            }

            if (!String.IsNullOrEmpty(this.sCssClass)) writer.AddAttribute(HtmlTextWriterAttribute.Class, this.sCssClass);
            if (!String.IsNullOrEmpty(this.DataPlaceHolder)) writer.AddAttribute("data-placeholder", this.DataPlaceHolder);

            if (ScriptManager.GetCurrent(this.Page) != null)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "init" + ClientID, script, true);
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "init" + ClientID, script, true);

            base.Render(writer);
        }

        #endregion Render

        #region OnDataBound

        protected override void OnDataBound(EventArgs e)
        {
            CheckAllowSingleDeselect();
            base.OnDataBound(e);
        }

        #endregion OnDataBound

        // ###################

        #region OnPreRender

        /// <summary>
        /// The OnPreRender event. Use this event to raise any events that need to be fired before
        /// our controls are rendered.
        /// </summary>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            JavaScriptHelper.Include_ChosenPlugin(this);
        }

        #endregion OnPreRender

        // ###################

        #region Private Methods

        /// <summary>
        /// Adds the CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        private void AddCssClass(string cssClass)
        {
            if (String.IsNullOrEmpty(this.sCssClass))
            {
                this.sCssClass = cssClass;
            }
            else
            {
                this.sCssClass += " " + cssClass;
            }
        }

        private void CheckAllowSingleDeselect()
        {
            if (AllowSingleDeselect || DataPlaceHolder != string.Empty)
            {
                this.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                this.SelectedIndex = 0;
            }
        }

        #endregion Private Methods
    }
}