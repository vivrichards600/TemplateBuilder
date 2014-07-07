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
    Public Sub PageIsPresented()

        'Arrange & Act
        WebBrowser.Navigate.GoToUrl("http://localhost:52095/TemplateBuilderForm.aspx")

        'Assert
        Assert.AreEqual(WebBrowser.Title, "Template Builder")

    End Sub

End Class
