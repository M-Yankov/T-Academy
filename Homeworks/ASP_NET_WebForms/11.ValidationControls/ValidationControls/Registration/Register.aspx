<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Registration.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ValidationSummary runat="server" DisplayMode="BulletList" EnableClientScript="false"
            HeaderText="Login info"
            ValidationGroup="LoginInfo"
            ID="summary" Style="color: red;" />
        <asp:ValidationSummary runat="server" DisplayMode="BulletList" EnableClientScript="false"
            HeaderText="Personal info"
            ValidationGroup="PersonalInfo"
            ID="ValidationSummary1" Style="color: red;" />
        <asp:ValidationSummary runat="server" DisplayMode="BulletList" EnableClientScript="false"
            HeaderText="Address info"
            ValidationGroup="AddressInfo"
            ID="ValidationSummary2" Style="color: red;" />
        <div>
            <div>

                <asp:Label Text="Username" runat="server" />
                <asp:TextBox runat="server" ID="tbUsername" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbUsername"
                    ValidationGroup="LoginInfo" Display="None" ErrorMessage="Username is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>
            <div>

                <asp:Label Text="Password" runat="server" />
                <asp:TextBox runat="server" ID="tbPass" TextMode="Password" />

                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbPass" Display="None"
                    ValidationGroup="LoginInfo" ErrorMessage="Password is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label Text="Repeat password" runat="server" />

                <asp:TextBox runat="server" ID="tbRepeatPass" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbRepeatPass"
                    ValidationGroup="LoginInfo" Display="None" ErrorMessage="Repeat pass is required"
                    EnableClientScript="false">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server"
                    ValidationGroup="LoginInfo" ControlToCompare="tbPass" EnableClientScript="false" ControlToValidate="tbRepeatPass"
                    ErrorMessage="Passwords mismatch!">
                    
                </asp:CompareValidator>
            </div>
            <div>

                <asp:Label Text="First name" runat="server" />
                <asp:TextBox runat="server" ID="tbFName" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbFName"
                    ValidationGroup="PersonalInfo" Display="None" ErrorMessage="FirstName is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>
            <div>

                <asp:Label Text="Last name" runat="server" />
                <asp:TextBox runat="server" ID="tvLName" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tvLName"
                    ValidationGroup="PersonalInfo" Display="None" ErrorMessage="Last name is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>

            <div>

                <asp:Label Text="Age" runat="server" />
                <asp:TextBox runat="server" Min="1" MAx="81" ID="Age" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="Age"
                    ValidationGroup="PersonalInfo" Display="None" ErrorMessage="Age is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server"
                    ValidationGroup="PersonalInfo" ControlToValidate="Age" EnableClientScript="false" MinimumValue="18" MaximumValue="81" ErrorMessage="Age must be between 18 and 81"></asp:RangeValidator>
            </div>
            <div>

                <asp:Label Text="Email" runat="server" />
                <asp:TextBox runat="server" ID="tbEmail" TextMode="Email" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid Email"
                    ValidationExpression="^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$" EnableClientScript="false" ControlToValidate="tbEmail" runat="server" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbEmail" Display="None" ErrorMessage="Email is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>
            <div>

                <asp:Label Text="Local address" runat="server" />
                <asp:TextBox runat="server" ID="tbAddress" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbAddress"
                    ValidationGroup="AddressInfo" Display="None" ErrorMessage="Address is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
            </div>

            <div>

                <asp:Label Text="Phone" runat="server" />
                <asp:TextBox runat="server" ID="tbPhone" />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true"
                    ControlToValidate="tbPhone"
                    ValidationGroup="AddressInfo" Display="None" ErrorMessage="Phone is required"
                    EnableClientScript="false">*
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ValidationGroup="AddressInfo" EnableClientScript="false" ValidationExpression="[\d]{10}"
                    ErrorMessage="Phone must contains 10 digits" ControlToValidate="tbPhone" runat="server" />
            </div>
            <asp:CheckBox Text="I accept to sell my body (to the devil)" runat="server" />
            <asp:Button Text="Check address info"
                ValidationGroup="AddressInfo" runat="server" />
            <asp:Button Text="Check Personal info"
                ValidationGroup="PersonalInfo" runat="server" />
            <asp:Button Text="Check login info"
                ValidationGroup="LoginInfo" runat="server" />
            <div>

                <asp:RadioButton Text="Male" ToolTip="This is the right" GroupName="genre" ID="radMale" runat="server" AutoPostBack="true" />
                <asp:RadioButton Text="Female" GroupName="genre" ID="radFemale" runat="server" AutoPostBack="true" />

            </div>
            <div style="display: inline-block">
                <asp:CheckBoxList runat="server" ID="chkCars" Visible='false'>
                    <asp:ListItem Text="BMW" />
                    <asp:ListItem Text="Audi" />
                    <asp:ListItem Text="VW" />
                    <asp:ListItem Text="Peugeot" />
                    <asp:ListItem Text="Mercedes" />
                </asp:CheckBoxList>
            </div>
            <div  style="display: inline-block">
                <asp:CheckBoxList runat="server" ID="chkCoffes" Visible='false'>
                    <asp:ListItem Text="Lavaca" />
                    <asp:ListItem Text="Late" />
                    <asp:ListItem Text="Nes" />
                    <asp:ListItem Text="Choco" />
                    <asp:ListItem Text="Dalgo" />
                    <asp:ListItem Text="Kaso" />
                </asp:CheckBoxList>
            </div>
        </div>
    </form>
</body>
</html>
