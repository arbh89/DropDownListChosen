<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:DropDownListChosen ID="ddlTest" DataPlaceHolder="Please select an option" AllowSingleDeselect="true" NoResultsText="No result found" DisableSearchThreshold="10" runat="server"></asp:DropDownListChosen>
    <asp:DropDownList ID="Dropdownlist1" runat="server"></asp:DropDownList>
</asp:Content>