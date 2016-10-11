<%@ Page Title="Week Four | Hello" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hello.aspx.cs" Inherits="week_six.hello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- All visible content goes here -->
    
    <h1>Hello</h1>

    <div>
        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
    </div> <!-- end div -->
    
    <asp:TextBox ID="txtName" runat="server" placeholder="Enter your name"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
</asp:Content>
