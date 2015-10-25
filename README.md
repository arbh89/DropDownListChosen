# DropDownListChosen

The ASP.NET DropDownList is an easy way to offer a set of selections for the user. However, if you want to allow the user to enter information not available in the dropdown list, you will have to write your own JavaScript code or jQuery. This source code combines that work into an ASP.NET DLL control you can easily place on any ASP.NET web page.

The downloadable source project above uses the following technologies:

- ASP.NET 4.0 / Webforms
- C#
- jQuery
- Chosen JQuery Plugin
- Chosen CSS

To use the DropDownListChosen, you will need to follow these steps:

1. Install the Nuget Package 
    - Install-Package DropDownListChosen
2. Add the control tag in your webform:

```html
<asp:DropDownListChosen ID="DropDownListChosen1" runat="server" 
            NoResultsText="No results match." width="350px"            
            DataPlaceHolder="Type Here..." AllowSingleDeselect="true">                
        </asp:DropDownListChosen> 
```
Bind items to your dropdown list either manually by adding ListItems to the DropDownListChosen or by binding to a DataSource. 
Datasource example can be found in the downloadable source code above.
You're done! You can now work with your DropDownListChosen to find what options work best for you. I would love to hear some great feedback if you use this control on your site