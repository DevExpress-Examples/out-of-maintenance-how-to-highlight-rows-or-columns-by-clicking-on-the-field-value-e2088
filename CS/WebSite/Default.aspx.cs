using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraPivotGrid;
using DevExpress.Web.ASPxPivotGrid;
using System.Drawing;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pivot.FieldValueTemplate = new FieldValueTemplate();
    }

    private string SelectedValue;
    private PivotArea SelectedArea;

    protected void OnASPxPivotGridCustomCallback(object sender, PivotGridCustomCallbackEventArgs e) {
        string[] args = e.Parameters.Split('|');
        if ("SL" == args[0]) {
            if (null == Session["SelectedValue"]) Session.Add("SelectedValue", args[1]);
            else Session["SelectedValue"] = args[1];
            if (null == Session["SelectedArea"])
                Session.Add("SelectedArea", Enum.Parse(typeof(PivotArea), args[2]));
            else Session["SelectedArea"] = Enum.Parse(typeof(PivotArea), args[2]);
        }
    }

    protected void OnASPxPivotGridCustomCellStyle(object sender, PivotCustomCellStyleEventArgs e) {
        if (null == Session["SelectedValue"] || null == Session["SelectedArea"])
            e.CellStyle.BackColor = Color.White;
        else {
            string selectedValue = (string)Session["SelectedValue"];
            PivotArea selectedArea = (PivotArea)Session["SelectedArea"];
            if (PivotArea.ColumnArea == selectedArea) {
                if (e.ColumnValueType == PivotGridValueType.GrandTotal)
                    e.CellStyle.BackColor =
                        "Grand Total" == selectedValue ? Color.AliceBlue : Color.White;
                else {
                    bool selected = false;
                    foreach (PivotGridField field in e.GetColumnFields())
                        if (e.GetFieldValue(field).ToString() == selectedValue) {
                            selected = true;
                            break;
                        }
                    e.CellStyle.BackColor = selected ? Color.AliceBlue : Color.White;
                }
            } else if (PivotArea.RowArea == selectedArea) {
                if (e.RowValueType == PivotGridValueType.GrandTotal)
                    e.CellStyle.BackColor =
                        "Grand Total" == selectedValue ? Color.AliceBlue : Color.White;
                else {
                    bool selected = false;
                    foreach (PivotGridField field in e.GetRowFields())
                        if (e.GetFieldValue(field).ToString() == selectedValue) {
                            selected = true;
                            break;
                        }
                    e.CellStyle.BackColor = selected ? Color.AliceBlue : Color.White;
                }
            } else e.CellStyle.BackColor = Color.White;
        }
    }

    public class FieldValueTemplate :ITemplate {
        #region ITemplate Members

        public void InstantiateIn(Control container) {
            PivotGridFieldValueTemplateContainer c = (PivotGridFieldValueTemplateContainer)container;
            ASPxLabel label = new ASPxLabel();
            label.Text = c.Text;
            label.JSProperties.Add("cpArea", c.ValueItem.Area.ToString());
            string val =
                PivotGridValueType.GrandTotal == c.ValueItem.ValueType ? "Grand Total" : c.Value.ToString();
            label.JSProperties.Add("cpValue", val);
            label.ClientSideEvents.Click =
                "function(s, e) { pivot.PerformCallback('SL|' + s.cpValue + '|' + s.cpArea); }";
            label.EnableViewState = false;
            c.Controls.Add(label);
        }

        #endregion
    }
}
