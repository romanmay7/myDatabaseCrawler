<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FillOrCancel.aspx.cs" Inherits="MyDatabaseCrawler.FillOrCancel" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" >
        <div>
            <br />
            <br />
            Order ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFindByOrderID" runat="server" Text="Find Order" Width="147px" OnClick="btnFindByOrderID_Click" />
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <br />
            <asp:Label ID="Label1" runat="server" Text="If filling an order,specify filled date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="dtpFillDate" runat="server" Height="21px" style="margin-right: 1px; margin-top: 6px" Width="233px"></asp:TextBox>
            &nbsp;&nbsp;
            <br />
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="dvgCustomerOrders" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID"  Height="252px"  Width="691px">
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
                    <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                    <asp:BoundField DataField="FilledDate" HeaderText="FilledDate" SortExpression="FilledDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="myLocalDB" runat="server" ConnectionString="<%$ ConnectionStrings:myLocalDB %>" SelectCommand="SELECT * From Sales.Orders"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <br />
            <br />
            <asp:Button ID="btnCancelOrder" runat="server"  Text="Cancel Order" OnClick="btnCancelOrder_Click" Width="141px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFillOrder" runat="server" Text="Fill Order" OnClick="btnFillOrder_Click" Width="156px" />
            <br />
        </asp:Panel>
    </form>
</asp:Content>
