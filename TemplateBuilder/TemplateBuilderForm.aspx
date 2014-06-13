<%@ Page AutoEventWireup="false" CodeBehind="TemplateBuilderForm.aspx.vb" Inherits="TemplateBuilder.TemplateBuilderForm"
    Language="vb" %>

<!DOCTYPE html>
<html>
<head>
    <title>Template Builder</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/sticky-footer.css" rel="stylesheet" type="text/css" />
    <link href="css/docs.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <!-- Fixed navbar -->
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Template builder</a>
            </div>
            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Home</a></li>
                    <li><a href="#about">About</a></li>
                    <li><a href="#contact">Contact</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </div>
    <!-- Begin page content -->
    <div class="container">
        <div class="page-header">
            <h1>
                Template builder</h1>
        </div>
        <form role="form" runat="server">
        <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary" CssClass="bs-callout bs-callout-danger"
                runat="server" DisplayMode="List" ValidationGroup="TemplateBuilderFormValidation" />
        </div>
        <div class="form-group">
            <label for="InputParametersTextBox">
                Project parameters</label>
            <asp:TextBox ID="InputParametersTextBox" class="form-control" runat="server" placeholder="Enter project parameters"></asp:TextBox><asp:RequiredFieldValidator
                ID="InputParametersRequiredFieldValidator" runat="server" ErrorMessage="<h4>Please correct the following errors</h4>Input parameters are mandatory and must contain i.e ProjectName TemplateName Field:Type(OptionalSize)"
                ControlToValidate="InputParametersTextBox" CssClass="bs-callout bs-callout-danger"
                Display="None" ValidationGroup="TemplateBuilderFormValidation"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="GeneratedOutputTextBox">
                Generated template</label>
            <asp:TextBox ID="GeneratedOutputTextBox" runat="server" class="form-control" placeholder="Generated code"></asp:TextBox>
        </div>
        <div class="btn-group">
            <asp:Button ID="GenerateTemplateButton" runat="server" Text="Generate Template" CssClass="btn btn-primary"
                ValidationGroup="TemplateBuilderFormValidation" />
        </div>
        </form>
    </div>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
