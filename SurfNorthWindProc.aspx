<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SurfNorthWindProc.aspx.cs" Inherits="MyDatabaseCrawler.SurfNorthWindProc" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" >
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="NorthWind Surfer"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server">
            Filter By&nbsp;
            <asp:DropDownList ID="FilterBy" runat="server">
                <asp:ListItem Value="ContactName">ContactName</asp:ListItem>
                <asp:ListItem Value="CompanyName">CompanyName</asp:ListItem>
                <asp:ListItem Value="TotalOrders">TotalOrders</asp:ListItem>
                <asp:ListItem Value="Phone">Phone </asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; Filter Options&nbsp;
            <asp:DropDownList ID="FilterOption" runat="server">
                <asp:ListItem Value="BeginWith">Begin With</asp:ListItem>
                <asp:ListItem Value="Includes">Includes</asp:ListItem>
                <asp:ListItem Value="EndsWith">Ends With</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SearchField" runat="server" Width="397px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" style="margin-left: 1px" Text="Search" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False"  Width="817px">
                <Columns>
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="TotalOrders" HeaderText="TotalOrders" SortExpression="TotalOrders" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="NorthWind" runat="server" ConnectionString="<%$ ConnectionStrings:myLocalDB2 %>" SelectCommand="SELECT [ContactName], [CompanyName], [Phone],[TotalOrders] FROM [Customers]"></asp:SqlDataSource>
            <br />
            <br />
            <br />
        </asp:Panel>
    </form>
</asp:Content>
