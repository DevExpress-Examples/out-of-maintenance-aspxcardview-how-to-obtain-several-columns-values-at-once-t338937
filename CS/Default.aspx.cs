using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        GetSelectedValues();
        PrintSelectedValues();
    }
    List<object> selectedValues;
    
    private void GetSelectedValues()
    {
        List<string> fieldNames = new List<string>();
        foreach (CardViewColumn column in ASPxCardView1.Columns)
            if (column is CardViewColumn)
                fieldNames.Add(((CardViewColumn)column).FieldName);
        selectedValues = ASPxCardView1.GetSelectedFieldValues(fieldNames.ToArray());
    }

    private void PrintSelectedValues()
    {
        if (selectedValues == null) return;
        string result = "";
        foreach (object[] item in selectedValues)
        {
            foreach (object value in item)
            {
                result += string.Format("{0}    ", value);
            }
            result += "</br>";
        }
        Literal1.Text = result;
    }
}