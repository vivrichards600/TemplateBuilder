Imports System.Text
Imports TemplateBuilder

<TestClass()>
Public Class GenerateTemplateUnitTests

    <TestMethod()>
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_When_Generating_Template_Code_But_No_Parameters_Input()
        Generate.Template(NO_PARAMETERS)
    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_If_Input_Parameters_Only_Contains_Template_Name()
        Generate.Template(FORM_TEMPLATE_PARAMETER)
    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_If_Input_Parameters_Only_Contains_Template_And_Form_Name()
        Generate.Template(FORM_TEMPLATE_PARAMETER + FORM_NAME_PARAMETER)
    End Sub

    <TestMethod()> _
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_If_Input_Parameters_Contains_Invalid_Field_Parameter()
        Generate.Template(FORM_TEMPLATE_PARAMETER + FORM_NAME_PARAMETER + FORM_FIELD_INVALID_PARAMETER)
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_When_Parameters_Field_Contains_Invalid_Data_Type()
        Generate.Template(INVALID_INPUT_PARAMETERS)
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_When_Parameters_Field_Contains_Field_Size_Without_Opening_Bracket()
        Generate.Template(FORM_TEMPLATE_PARAMETER + FORM_NAME_PARAMETER + "Field1:Varchar200)")
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_When_Parameters_Field_Contains_Field_Size_Without_Closing_Bracket()
        Generate.Template(FORM_TEMPLATE_PARAMETER + FORM_NAME_PARAMETER + "Field1:Varchar(200")
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.Exception))> _
    Public Sub Throw_Exception_When_Parameters_Field_Contains_Field_Size_Opening_And_Closing_Brackets_But_No_Size()
        Generate.Template(FORM_TEMPLATE_PARAMETER + FORM_NAME_PARAMETER + "Field1:Varchar()")
    End Sub

    <TestMethod()>
    Public Sub Generate_HTML_Template_Code_When_Parameters_Input()
        GENERATED_OUTPUT = Generate.Template(INPUT_PARAMETERS)

        Assert.AreEqual(EXPECTED_GENERATED_OUTPUT, GENERATED_OUTPUT)
    End Sub

    <TestMethod()>
    Public Sub Input_Project_And_Form_Name_Parameters_Should_Be_Included_In_Generated_HTML_Template_Code_Opening_Tag()
        GENERATED_OUTPUT = Generate.Template("PayAward DisplayPayAward StaffName:Varchar(200)")

        Assert.AreEqual("<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""PayAward.aspx.vb"" Inherits=""DisplayPayAward.PayAward"" %>" & vbCrLf & "<!DOCTYPE html>" & vbCrLf & "<html>" & vbCrLf & "<head>" & vbCrLf & "<title>DisplayPayAward</title>" & vbCrLf & "</head>" & vbCrLf & "<body>" & vbCrLf & "</body>" & vbCrLf & "</html>", GENERATED_OUTPUT)
    End Sub

    <TestMethod()>
    Public Sub Basic_HTML_Markup_Should_Be_Included_In_Generated_HTML_Template_Code_Opening_Tag()
        GENERATED_OUTPUT = Generate.Template("PayAward DisplayPayAward StaffName:Varchar(200)")

        Assert.AreEqual("<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""PayAward.aspx.vb"" Inherits=""DisplayPayAward.PayAward"" %>" & vbCrLf & "<!DOCTYPE html>" & vbCrLf & "<html>" & vbCrLf & "<head>" & vbCrLf & "<title>DisplayPayAward</title>" & vbCrLf & "</head>" & vbCrLf & "<body>" & vbCrLf & "</body>" & vbCrLf & "</html>", GENERATED_OUTPUT)
    End Sub

    Public Shared Generate As Generate

    <TestInitialize()>
    Public Sub Initialization()
        Generate = New Generate
    End Sub

    Dim NO_PARAMETERS = String.Empty
    Dim FORM_TEMPLATE_PARAMETER = "ProjectName"
    Dim FORM_NAME_PARAMETER = " FormName"
    Dim FORM_FIELD_INVALID_PARAMETER = " Field:Type"
    Dim INPUT_PARAMETERS = "ProjectName FormName fIRSTnAME:varchar(200)"
    Dim INVALID_INPUT_PARAMETERS = "ProjectName FormName Field1:SomeInvalidType"
    Dim EXPECTED_GENERATED_OUTPUT = "<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""ProjectName.aspx.vb"" Inherits=""FormName.ProjectName"" %>" & vbCrLf & "<!DOCTYPE html>" & vbCrLf & "<html>" & vbCrLf & "<head>" & vbCrLf & "<title>FormName</title>" & vbCrLf & "</head>" & vbCrLf & "<body>" & vbCrLf & "</body>" & vbCrLf & "</html>"
    Dim GENERATED_OUTPUT As String = String.Empty

End Class
