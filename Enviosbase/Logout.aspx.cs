using System;

namespace Enviosbase
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CerrarSession();
            }
        }

        public void CerrarSession()
        {
            try
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}