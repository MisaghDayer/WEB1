using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            DataSet1TableAdapters.Table_1TableAdapter tesst = new DataSet1TableAdapters.Table_1TableAdapter();
            tesst.Insert(TxtName.Text.Trim(),TxtFamily.Text.Trim());
            GridView1.DataBind();
        }


    }
}