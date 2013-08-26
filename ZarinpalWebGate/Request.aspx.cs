using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZarinpalWebGate
{
    public partial class RequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            zarinpal.PaymentGatewayImplementationService zp = new zarinpal.PaymentGatewayImplementationService();
            string Authority;

            int Status = zp.PaymentRequest("4c8a4b74-02c4-4674-ad57-2e3eae8e8897", int.Parse(txtAmount.Text), txtDescription.Text.ToString(), "you@yoursite.com", "09123456789", "http://localhost/Verify.aspx", out Authority);

            if (Status == 100)
            {
                Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
            }
            else
            {
                Response.Write("error: " + Status);
            }
        }
    }
}