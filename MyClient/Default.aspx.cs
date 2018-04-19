using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClient.MyMulServiceReference ;

namespace MyClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MulServiceClient client = new MulServiceClient("BasicHttpBinding_IMulService");

            lbl1.InnerText = client.Mul(1, 2).ToString();
        }
    }
}