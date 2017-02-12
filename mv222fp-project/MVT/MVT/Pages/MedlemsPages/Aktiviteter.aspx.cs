using System;
using System.Collections.Generic;
using System.Web.UI;
using MVT.Model;


namespace MVT.Pages.MedlemsPages
{
        public partial class Aktiviteter  : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Visar eventuella meddelanden lagrade i de temporära sessionsvariablerna.
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        // Hämtar ut alla aktiviteter.
        public IEnumerable<MVT.Model.Activity> ActivityListView_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetActivities();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då aktiviteterna skulle hämtas från databasen.");
                return null;
            }
        }
    }
}
