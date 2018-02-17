<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePanelDemo.aspx.cs" Inherits="Demo.Web.UpdatePanelDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server">
                <asp:DropDownListChosen ID="ddlTest" DataPlaceHolder="Please select an option" AllowSingleDeselect="true" NoResultsText="No result found" DisableSearchThreshold="10" runat="server"></asp:DropDownListChosen>
                <asp:DropDownList ID="Dropdownlist1" runat="server"></asp:DropDownList>

                <asp:Button ID="btnSubmit" Text="Click Me" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>