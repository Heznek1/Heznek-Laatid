<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 154px;
            height: 132px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" dir="rtl">
        <div style="width: 173px; font-family: 'Arial Black'; font-size: 30px; text-decoration: underline overline; font-weight: normal; color: #000000; background-color: #FFFFFF;">
            הזנק לעתיד</div>
        <p dir="rtl">
            שם משתמש:<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        סיסמא:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 11px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server" Text="הודעת מערכת" Enabled="False" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="התחבר" />
            <img alt="" class="auto-style1" dir="rtl" src="../img/mob5tertv-profile_image-695ed5e0a42064bb-300x300.png" /></p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT [id], [password], [userType] FROM [loginAndPermissions]"></asp:SqlDataSource>
    </form>
</body>
</html>
