Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraLayout
Imports System.ComponentModel
Imports DevExpress.Utils.Controls
Imports DevExpress.Utils.Serializing

Namespace CustomGridColumn_MaxRowHeight
	Public Class CustomGridView
		Inherits GridView
		Public Sub New()
			MyBase.New()
		End Sub
		Protected Friend Overridable Sub SetGridControlAccessMetod(ByVal newControl As GridControl)
			SetGridControl(newControl)
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomGridView"
			End Get
		End Property

		Protected Overrides Function CreateOptionsView() As ColumnViewOptionsView
			Return New CustomGridOptionsView()
		End Function
		<Description("Provides access to the View's display options."), Category("Options"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), XtraSerializableProperty(XtraSerializationVisibility.Content, XtraSerializationFlags.DefaultValue), XtraSerializablePropertyId(LayoutIdOptionsView)> _
		Public Shadows ReadOnly Property OptionsView() As CustomGridOptionsView
			Get
				Return TryCast(MyBase.OptionsView, CustomGridOptionsView)
			End Get
		End Property
	End Class

	Public Class CustomGridControl
		Inherits GridControl
		Public Sub New()
			MyBase.New()
		End Sub
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New CustomGridInfoRegistrator())
		End Sub
		Protected Overrides Function CreateDefaultView() As BaseView
			Return CreateView("CustomGridView")
		End Function
	End Class

	Public Class CustomGridInfoRegistrator
		Inherits GridInfoRegistrator
		Public Sub New()
			MyBase.New()
		End Sub
		Public Overrides Function CreateViewInfo(ByVal view As BaseView) As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo
			Return New CustomGridViewInfo(TryCast(view, GridView))
		End Function
		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomGridView"
			End Get
		End Property
		Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
			Dim view As New CustomGridView()
			view.SetGridControlAccessMetod(grid)
			Return view
		End Function
	End Class
	Public Class CustomGridViewInfo
		Inherits GridViewInfo
		Public Sub New(ByVal gridView As GridView)
			MyBase.New(gridView)
		End Sub
		Protected Overrides Function CalcRowAutoHeight(ByVal g As System.Drawing.Graphics, ByVal colInfo As GridColumnsInfo, ByVal rowHandle As Integer, ByVal useCache As Boolean, ByVal level As Integer) As Integer
			If (CType(View, CustomGridView)).OptionsView.MaxRowHeight > 0 Then
				Return Math.Min((CType(View, CustomGridView)).OptionsView.MaxRowHeight, MyBase.CalcRowAutoHeight(g, colInfo, rowHandle, useCache, level))
			End If
			Return MyBase.CalcRowAutoHeight(g, colInfo, rowHandle, useCache, level)
		End Function
	End Class
	Public Class CustomGridOptionsView
		Inherits GridOptionsView
		Private maxRowHeight_Renamed As Integer
		Public Sub New()
			MyBase.New()
			maxRowHeight_Renamed = -1
		End Sub
		<Description("Get or set maximum row height."), DefaultValue(-1), XtraSerializableProperty()> _
		Public Overridable Property MaxRowHeight() As Integer
			Get
				Return maxRowHeight_Renamed
			End Get
			Set(ByVal value As Integer)
				If maxRowHeight_Renamed = value Then
					Return
				End If
				Dim prevValue As Integer = maxRowHeight_Renamed
				maxRowHeight_Renamed = value
				OnChanged(New BaseOptionChangedEventArgs("MaxRowHeight", prevValue, MaxRowHeight))
			End Set
		End Property
	End Class
End Namespace
