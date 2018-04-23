using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraLayout;
using System.ComponentModel;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Serializing;

namespace CustomGridColumn_MaxRowHeight
{
    public class CustomGridView : GridView
    {
        public CustomGridView() : base() { }
        protected internal virtual void SetGridControlAccessMetod(GridControl newControl) { SetGridControl(newControl); }
        protected override string ViewName { get { return "CustomGridView"; } }

        protected override ColumnViewOptionsView CreateOptionsView()
        {
            return new CustomGridOptionsView();
        }
        [Description("Provides access to the View's display options."), Category("Options"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        XtraSerializableProperty(XtraSerializationVisibility.Content, XtraSerializationFlags.DefaultValue),
        XtraSerializablePropertyId(LayoutIdOptionsView)]
        public new CustomGridOptionsView OptionsView { get { return base.OptionsView as CustomGridOptionsView; } }
    }

    public class CustomGridControl : GridControl
    {
        public CustomGridControl() : base() { }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridInfoRegistrator());
        }
        protected override BaseView CreateDefaultView() { return CreateView("CustomGridView"); }
    }

    public class CustomGridInfoRegistrator : GridInfoRegistrator
    {
        public CustomGridInfoRegistrator() : base() { }
        public override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(BaseView view) { return new CustomGridViewInfo(view as GridView); }
        public override string ViewName { get { return "CustomGridView"; } }
        public override BaseView CreateView(GridControl grid)
        {
            CustomGridView view = new CustomGridView();
            view.SetGridControlAccessMetod(grid);
            return view;
        }
    }
    public class CustomGridViewInfo : GridViewInfo
    {
        public CustomGridViewInfo(GridView gridView) : base(gridView) { }
        protected override int CalcRowAutoHeight(System.Drawing.Graphics g, GridColumnsInfo colInfo, int rowHandle, int rowVisibleIndex, bool useCache, int level)
        {
            if (((CustomGridView)View).OptionsView.MaxRowHeight > 0)
                return Math.Min(((CustomGridView)View).OptionsView.MaxRowHeight, base.CalcRowAutoHeight(g, colInfo, rowHandle, rowVisibleIndex, useCache, level));
            return base.CalcRowAutoHeight(g, colInfo, rowHandle, rowVisibleIndex, useCache, level);
        }
    }
    public class CustomGridOptionsView : GridOptionsView
    {
        int maxRowHeight;
        public CustomGridOptionsView()
            : base()
        {
            maxRowHeight = -1;
        }
        [Description("Get or set maximum row height."), DefaultValue(-1), XtraSerializableProperty()]
        public virtual int MaxRowHeight
        {
            get { return maxRowHeight; }
            set
            {
                if (maxRowHeight == value) return;
                int prevValue = maxRowHeight;
                maxRowHeight = value;
                OnChanged(new BaseOptionChangedEventArgs("MaxRowHeight", prevValue, MaxRowHeight));
            }
        }
    }
}
