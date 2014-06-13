Imports TemplateBuilder.Generate
Public Class TemplateBuilderForm
    Inherits System.Web.UI.Page

    Protected Sub GenerateTemplateButton_Click(sender As Object, e As EventArgs) Handles GenerateTemplateButton.Click

        Try
            GeneratedOutputTextBox.Text = Template(InputParametersTextBox.Text)

        Catch ex As Exception
            AddValidationMessage(ex.Message.ToString())
        End Try


    End Sub

    Sub AddValidationMessage(errorMessage As String)
        Dim err As New CustomValidator
        err.ValidationGroup = "TemplateBuilderFormValidation"
        err.IsValid = False
        err.ErrorMessage = "<h4>Please correct the following errors</h4>" & errorMessage
        ValidationSummary.Controls.Add(err)
    End Sub

End Class