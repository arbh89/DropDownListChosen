using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

[assembly: WebResource("DropDownListChosen.js.chosen.jquery.js", "application/x-javascript")]

namespace DropDownListChosen
{
    internal class JavaScriptHelper
    {
        #region Constants

        private const string NAME_CHOSEN_JQUERY = "DropDownListChosen.js.chosen.jquery.js";

        #endregion Constants

        #region Chosen Bootstrap

        /// <summary>
        /// Includes DropDownChosen.js.chosen.jquery.js in the page.
        /// </summary>
        /// <param name="manager">Accessible via Page.ClientScript.</param>
        public static void Include_ChosenPlugin(ClientScriptManager manager)
        {
            // chosen.jquery.js
            IncludeJavaScript(manager, NAME_CHOSEN_JQUERY);
        }

        /// <summary>
        /// Includes DropDownChosen.js.chosen.jquery.js in the page.
        /// </summary>
        /// <param name="ctrl">Accessible via Control.</param>
        internal static void Include_ChosenPlugin(Control ctrl)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(ctrl.Page);
            ClientScriptManager manager = ctrl.Page.ClientScript;
            if (scriptManager != null)
            {
                if (scriptManager.IsInAsyncPostBack)
                {
                    IncludeJavaScript(ctrl, NAME_CHOSEN_JQUERY);
                }
                else
                {
                    IncludeJavaScript(ctrl.Page, NAME_CHOSEN_JQUERY);
                }
            }
            else
            {
                IncludeJavaScript(manager, NAME_CHOSEN_JQUERY);
            }
        }

        #endregion Chosen Bootstrap

        #region Private Methods

        /// <summary>
        /// Includes the specified embedded JavaScript file in the page.
        /// </summary>
        /// <param name="manager">Accessible via Page.ClientScript.</param>
        /// <param name="resourceName">The name used to identify the embedded JavaScript file.</param>
        private static void IncludeJavaScript(ClientScriptManager manager, string resourceName)
        {
            var type = typeof(JavaScriptHelper);
            if (!manager.IsClientScriptBlockRegistered(resourceName))
            {
                manager.RegisterClientScriptResource(type, resourceName);
            }
        }

        /// <summary>
        /// Registra el script de cliente que está incrustado en un ensamblado con el control
        /// System.Web.UI.ScriptManager para su uso con un control que participa en la
        /// representación parcial de página.
        /// </summary>
        /// <param name="ctrl">Control - Control que registra el script.</param>
        /// <param name="resourceName">string - Identificador del recurso.</param>
        private static void IncludeJavaScript(Control ctrl, string resourceName)
        {
            ScriptManager.RegisterClientScriptResource(ctrl, ctrl.GetType(), resourceName);
        }

        /// <summary>
        /// Registra un archivo de script de cliente que se incrusta en un ensamblado con el control
        /// System.Web.UI.ScriptManager cada vez que se produce un postback.
        /// </summary>
        /// <param name="page">Page - Objeto de página que registra el script.</param>
        /// <param name="resourceName">string - Identificador del recurso.</param>
        private static void IncludeJavaScript(Page page, string resourceName)
        {
            try
            {
                ScriptManager.RegisterClientScriptResource(page, page.GetType(), resourceName);
            }
            catch (Exception)
            {
                ClientScriptManager manager = page.ClientScript;
                IncludeJavaScript(manager, resourceName);
            }
        }

        #endregion Private Methods
    }
}