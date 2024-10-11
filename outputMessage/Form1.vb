Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub btnOutputMessage_Click(sender As Object, e As EventArgs) Handles btnOutputMessage.Click

        ' Connection string to connect to MySQL database
        Dim connectionString As String = "Server=localhost;Database=dbuser;User ID=root;Password=12Yellow34!"

        Using conn As New MySqlConnection(connectionString)

            ' Open the connection
            conn.Open()

            ' Query to get the output message
            Using cmd As New MySqlCommand("sp_outputMessage", conn)
                cmd.CommandType = CommandType.StoredProcedure

                ' Execute the query and read the result
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Retrieve and display the output message
                        Dim message As String = reader.GetString(0)
                        MessageBox.Show(message)
                    End If
                End Using

            End Using

        End Using

    End Sub
End Class
