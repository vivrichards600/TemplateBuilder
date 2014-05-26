﻿Public Class Generate
    ''' <summary>
    ''' Create a template based on input parameters
    ''' </summary>
    ''' <param name="inputParameters"></param>
    ''' <returns>Creates Web Form, Web Form Code, Web Form tests, SQL Scripts</returns>
    ''' <remarks>EXAMPLE USAGE: TemplateName FormName Field1:Varchar Field2:Int Field3:Date</remarks>
    Public Function Template(inputParameters As String) As String
        If String.IsNullOrWhiteSpace(inputParameters) Then Throw New Exception("no field parameter input")
        If inputParameters.Split(" ").Count <= 2 Then Throw New Exception("template of form name missing")

        CheckTypes(FieldParameters(inputParameters))
        CheckSize(FieldParameters(inputParameters))
        'fail if user field FieldParameters do not have valid field types





        Return "<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""ProjectName.aspx.vb"" Inherits=""FormName.TemplateName"" %>"

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
    ''' Check field parameter contains valid field type
    ''' </summary>
    Private Sub CheckTypes(ByVal parameters As List(Of String))
        If parameters.Any(Function(parameter) (parameter.Contains(":")) = False) Then Throw New Exception("field parameter requires a field name as well as a field type seperated with a :")

        If parameters.Any(Function(parameter) (parameter.ToLower.Contains("varchar") _
                                               Or parameter.ToLower.Contains("int") _
                                               Or parameter.ToLower.Contains("date")) = False) Then Throw New Exception("invalid type input for field parameter")
    End Sub

    ''' <summary>
    ''' Check field parameter contains a valid size if it's specified
    ''' </summary>
    ''' <param name="inputParameters"></param>
    ''' <remarks></remarks>
    Private Sub CheckSize(ByVal parameters As List(Of String))
        parameters.ForEach(Sub(parameter)

                               If parameter.Contains("(") = True And parameter.Contains(")") = True Then
                                   parameter = parameter.Replace("(", "")
                                   parameter = parameter.Replace(")", "")
                                   If IsNumeric(parameter) = False Then Throw New Exception("found an opening and closing bracket for field size but no number")
                               End If

                               If parameter.Contains("(") = True And parameter.Contains(")") = False Then Throw New Exception("found an opening bracket for field size but no closing bracket")
                               If parameter.Contains("(") = False And parameter.Contains(")") = True Then Throw New Exception("found a closing bracket for field size but no opening bracket")
                           End Sub)
    End Sub




End Class