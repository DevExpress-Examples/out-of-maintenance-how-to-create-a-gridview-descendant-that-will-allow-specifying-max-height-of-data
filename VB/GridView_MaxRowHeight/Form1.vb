Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections

Namespace GridView_MaxRowHeight
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private myUsers As New Users()
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			myUsers.Add(New User("Antuan", "Lorem ipsum"))
			myUsers.Add(New User("Bill", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit,"))
			myUsers.Add(New User("Charli", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat"))
			myUsers.Add(New User("Denn", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat"))
			myUsers.Add(New User("Eva", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat"))
			customGridControl1.DataSource = myUsers
			gridColumn1.FieldName = "Name"
			gridColumn2.FieldName = "Coment"

		End Sub
	End Class
	Public Class User
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
'INSTANT VB NOTE: The variable coment was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private name_Renamed, coment_Renamed As String
		Public Sub New(ByVal name As String, ByVal coment As String)
			Me.name_Renamed = name
			Me.coment_Renamed = coment
		End Sub
		Public Property Name() As String
			Set(ByVal value As String)
				name_Renamed = value
			End Set
			Get
				Return name_Renamed
			End Get
		End Property
		Public Property Coment() As String
			Set(ByVal value As String)
				coment_Renamed = value
			End Set
			Get
				Return coment_Renamed
			End Get
		End Property
	End Class
	Public Class Users
		Inherits ArrayList

		Default Public Overrides Property Item(ByVal index As Integer) As Object
			Get
				Return DirectCast(MyBase.Item(index), User)
			End Get
			Set(ByVal value As Object)
				MyBase.Item(index) = value
			End Set
		End Property
	End Class
End Namespace