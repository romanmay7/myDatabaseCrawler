<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyDatabaseCrawler.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contacts.</h3>
    <address>
        <strong>GitHub</strong>
        <a href="https://github.com/RomanMayer7">https://github.com/RomanMayer7</a>
        <br />
        <strong>LinkedIn</strong>
        <a href="https://www.linkedin.com/in/roman-mayerson-165b06178/">https://www.linkedin.com/in/roman-mayerson-165b06178/</a>
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
