<%@ Page AutoEventWireup="false" CodeBehind="TemplateBuilderForm.aspx.vb" Inherits="TemplateBuilder.TemplateBuilderForm"
    Language="vb" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Template Builder</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" 
            ValidationGroup="TemplateBuilderFormValidation" />
        <asp:TextBox ID="InputParametersTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="GenerateTemplateButton" runat="server" Text="Generate Template" 
            ValidationGroup="TemplateBuilderFormValidation" />
        <asp:RequiredFieldValidator ID="InputParametersRequiredFieldValidator" runat="server" 
            
            ErrorMessage="Input parameters are mandatory and must contain i.e ProjectName TemplateName Field:Type(OptionalSize)" 
            ControlToValidate="InputParametersTextBox" Display="Dynamic" 
            ValidationGroup="TemplateBuilderFormValidation"></asp:RequiredFieldValidator>
        <asp:TextBox ID="GeneratedOutputTextBox" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
