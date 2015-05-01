<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WingtipToys.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" SelectMethod="GetProduct" ItemType="WingtipToys.Models.Product" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#: Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#: Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.ProductName %>" />
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td style="vertical-align:top">
                        <b>Description:</b>
                        <br />
                        <%#: Item.Description %>
                        <br />
                        <b>Price:</b>&nbsp<%#: String.Format("{0:c}",Item.UnitPrice) %>
                        <br />
                        <b>Product Number:</b>&nbsp<%#: Item.ProductID %>
                    </td>
                </tr>
            </table>    
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
