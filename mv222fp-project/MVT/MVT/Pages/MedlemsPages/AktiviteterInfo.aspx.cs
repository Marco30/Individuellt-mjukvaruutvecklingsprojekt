using MVT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVT.Pages.MedlemsPages
{
    public partial class AktiviteterInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Visar eventuella meddelanden lagrade i de temporära sessionsvariablerna.
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        // Privat fält för service-klass.
        private Service _service;

        // Egenskap som initializerar ett service-objekt ifall det inte redan finns något.
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        // Hämtar alla medlemmar som utövar aktiviteten.
        public IEnumerable<MVT.Model.ActivityType> ActivityTypeListView_GetData([RouteData] int id)
        {
         
                return Service.GetActivityById(id);
     
        }

        //tarbort person från aktivtet 
        public void Person_Delete(ActivityType A)
        {
            try
            {
               
                Service.DeleteMemberActivityById(A);

                // Sparar ett rättmeddelande i en temporär sessionsvariabel och dirigerar användaren till listan med medlemmar.
                Page.SetTempData("SuccessMessage", "Medlem togs bort från aktivitet.");
                Response.RedirectToRoute("ActivityDetails", A.AktID);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemsaktiviteten skulle tas bort.");
            }
        }

    }
}