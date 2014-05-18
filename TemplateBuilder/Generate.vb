Public Class Generate
    ''' <summary>
    ''' Create a template based on input parameters
    ''' </summary>
    ''' <param name="inputParameters"></param>
    ''' <returns>Creates Web Form, Web Form Code, Web Form tests, SQL Scripts</returns>
    ''' <remarks>EXAMPLE USAGE: TemplateName FormName Field1:Varchar Field2:Int Field3:Date</remarks>
    Public Function Template(inputParameters As String) As String
        If String.IsNullOrWhiteSpace(inputParameters) Then Throw New Exception 'fail if we have no FieldParameters
        If inputParameters.Split(" ").Count <= 2 Then Throw New Exception 'fail if we have only a template or form name

        CheckTypes(FieldParameters(inputParameters)) 'fail if user field FieldParameters do not have valid field types

        Return "generated output"

    End Function

    ''' <summary>
    ''' Obtain list of field parameters
    ''' </summary>
    Private Function FieldParameters(ByVal usersParameters As String) As List(Of String)
        Dim listOfFieldParameters = usersParameters.Split(" ").ToList
        listOfFieldParameters.RemoveRange(0, 2)
        Return listOfFieldParameters
    End Function

    ''' <summary>
    ''' Throw exception is field parameter doesnt have a type or isn't varchar, int or date
    ''' </summary>
    Private Sub CheckTypes(ByVal parameters As List(Of String))
        If parameters.Any(Function(parameter) (parameter.Contains(":")) = False) Then Throw New Exception

        If parameters.Any(Function(parameter) (parameter.ToLower.Contains("varchar") _
                                               Or parameter.ToLower.Contains("int") _
                                               Or parameter.ToLower.Contains("date")) = False) Then Throw New Exception
    End Sub

End Class