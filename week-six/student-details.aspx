<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="week_six.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Student Details</h1>
    
    <div class="form-group">
        <div class="col-sm-offset-3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ErrorMessage="Last Name is Required" ControlToValidate="txtLastName"
            CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <label for="txtLastName" class="col-sm-3 control-label">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" />
    </div>
    <div class="form-group">
        <div class="col-sm-offset-3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ErrorMessage="First Name is Required" ControlToValidate="txtFirstName"
            CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <label for="txtFirstName" class="col-sm-3 control-label">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" />
    </div>
    <div class="form-group">
        <div class="col-sm-offset-3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
            ErrorMessage="Enrollment Date is Required" ControlToValidate="txtEnrollmentDate"
            CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <label for="txtEnrollmentDate" class="col-sm-3 control-label">Enrollment Date:</label>
        <div class="input-group date col-sm-3" id="datetimepicker1">
            <asp:TextBox ID="txtEnrollmentDate" runat="server" CssClass="form-control" required />
            <span class="input-group-addon">
                <span class="glyphicon glyphicon-calendar"></span>
            </span>
        </div>
    </div>

    <asp:Button CssClass="btn btn-success col-sm-offset-3" ID="btnSave" runat="server" text="Save" OnClick="btnSave_Click" />

</asp:Content>
