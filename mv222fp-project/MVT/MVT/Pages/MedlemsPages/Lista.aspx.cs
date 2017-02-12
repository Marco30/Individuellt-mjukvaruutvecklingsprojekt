using System;
using System.Collections.Generic;
using System.Web.UI;
using MVT.Model;

namespace MVT.Pages.MedlemsPages
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Visar meddelanden med text att man lyckats lägga till meddlem,  med andra ord visar text lagrade i de temporära sessionsvariablerna
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        public IEnumerable<MVT.Model.Member> MemberListView_GetData() // Hämtar alla kunde i databasen
        {
            try
            {
                Service service = new Service();
                return service.GetMembers();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmarna skulle hämtas från databasen.");
                return null;
            }
        }
    }
}