﻿Public Class Generate
    ''' <summary>
    ''' Create a template based on input parameters
    ''' </summary>
    ''' <param name="inputParameters"></param>
    ''' <returns>Creates Web Form, Web Form Code, Web Form tests, SQL Scripts</returns>
    ''' <remarks>EXAMPLE USAGE: TemplateName FormName Field1:Varchar Field2:Int Field3:Date</remarks>
    Public Shared Function Template(inputParameters As String) As String
        If String.IsNullOrWhiteSpace(inputParameters) Then Throw New Exception("No field parameter input")
        If inputParameters.Split(" ").Count < 2 Then Throw New Exception("Template or form name missing")
        If inputParameters.Split(" ").Count = 2 Then Throw New Exception("No field parameters specified")

        CheckTypes(FieldParameters(inputParameters))
        CheckSize(FieldParameters(inputParameters))

        Return String.Format("<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""{0}.aspx.vb"" Inherits=""{1}.{0}"" %>{2}<!DOCTYPE html>{2}<html>{2}<head>{2}<title>{1}</title>{2}</head>{2}<body>{2}</body>{2}</html>", inputParameters.Split(" ")(0), inputParameters.Split(" ")(1), vbCrLf)

      End Function

    ''' <summary>
    ''' Obtain list of field parameters
    ''' </summary>
    Private Shared Function FieldParameters(ByVal usersParameters As String) As List(Of String)
        Dim listOfFieldParameters = usersParameters.Split(" ").ToList
        listOfFieldParameters.RemoveRange(0, 2)
        
        Return listOfFieldParameters
    End Function

    ''' <summary>
    ''' Check field parameter contains valid field type
    ''' </summary>
    Private Shared Sub CheckTypes(ByVal parameters As List(Of String))
        If parameters.Any(Function(parameter) (parameter.Contains(":")) = False) Then Throw New Exception("Field parameter requires a field name as well as a field type seperated with a :")

        If parameters.Any(Function(parameter) (parameter.ToLower.Contains("varchar") _
                                               Or parameter.ToLower.Contains("int") _
                                               Or parameter.ToLower.Contains("date")) = False) Then Throw New Exception("Invalid type input for field parameter")
    End Sub

    ''' <summary>
    ''' Check field parameter contains a valid size if it's specified
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub CheckSize(ByVal parameters As List(Of String))
        parameters.ForEach(Sub(parameter)
                               If parameter.Contains("(") = True And parameter.Contains(")") = True Then
                                   'remove everything upto first opening bracket
                                   Dim userParameter As String = parameter
                                   Dim userParameterOpeningBracketIndex = parameter.IndexOf("("c)
                                   userParameter = Right(userParameter, userParameter.Length - userParameterOpeningBracketIndex)
                                   'remove brackets
                                   userParameter = userParameter.Replace("(", "").Replace(")", "")

                                   If IsNumeric(userParameter) = False Then Throw New Exception("Found an opening and closing bracket for field size but no number")
                               End If

                               If parameter.Contains("(") = True And parameter.Contains(")") = False Then Throw New Exception("Found an opening bracket for field size but no closing bracket")
                               If parameter.Contains("(") = False And parameter.Contains(")") = True Then Throw New Exception("Found a closing bracket for field size but no opening bracket")
                           End Sub)
    End Sub
End Class
