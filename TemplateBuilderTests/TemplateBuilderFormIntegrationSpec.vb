Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Firefox
Imports OpenQA.Selenium.IE

<TestClass()>
Public Class TemplateBuilderFormIntegrationSpec

    Private testContextInstance As TestContext
    Public Shared WebBrowser As IWebDriver

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

    <TestInitialize()>
    Public Sub Initialization()
        WebBrowser = New FirefoxDriver
    End Sub

    <TestCleanup()>
    Public Sub Termination()
        WebBrowser.Quit()
    End Sub

    ''' <summary>
    ''' Ensure that the page is presented
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub Page_Is_Presented()
        'Arrange & Act
        WebBrowser.Navigate.GoToUrl("http://localhost:52095/TemplateBuilderForm.aspx")

        'Assert
        Assert.AreEqual(WebBrowser.Title, "Template Builder")

    End Sub

    <TestMethod()> _
    Public Sub Page_Displays_Input_Parameters_Are_Mandatory_Error_When_No_Parameters_Input_And_Generate_Template_Button_Clicked()
        'Arrange
        WebBrowser.Navigate.GoToUrl("http://localhost:52095/TemplateBuilderForm.aspx")

        'Act
        WebBrowser.FindElement(By.Id("GenerateTemplateButton")).Click()

        'Assert
        Assert.IsTrue(WebBrowser.PageSource.Contains("Input parameters are mandatory and must contain i.e ProjectName TemplateName Field:Type(OptionalSize)"))
    End Sub

    <TestMethod()> _
    Public Sub Page_Displays_Template_Or_Form_Name_Missing_Error_When_Only_A_Project_Name_Input_And_Generate_Template_Button_Clicked()
        'Arrange
        WebBrowser.Navigate.GoToUrl("http://localhost:52095/TemplateBuilderForm.aspx")
        WebBrowser.FindElement(By.Id("InputParametersTextBox")).SendKeys("ProjectName")

        'Act
        WebBrowser.FindElement(By.Id("GenerateTemplateButton")).Click()

        'Assert
        Assert.IsTrue(WebBrowser.PageSource.Contains("Input parameters are mandatory and must contain i.e ProjectName TemplateName Field:Type(OptionalSize)"))
    End Sub
End Class
