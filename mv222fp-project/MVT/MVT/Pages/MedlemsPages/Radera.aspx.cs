using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVT.Model;

namespace MVT.Pages.MedlemsPages//Marco Villegas
{
    public partial class Radera : System.Web.UI.Page
    {
        // Privat fält för serviceklass
        private Service _service;


        private Service Service// Egenskap som initializerar/skapar ett serviceobjekt om det inte redan fin en 
        {
            get { return _service ?? (_service = new Service()); }
        }


        protected int Id// Hämtar den valda medlemmens id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            CancelHyperLink.NavigateUrl = GetRouteUrl("MemberDetails", new { id = Id });// Ger avbrytknappen sin URL så att man åter vänder till medlemmensInfo


            if (!IsPostBack)// om det inte är en postback hämtas medlemmens förnamn och efternamn som sedan presenteras i en sträng på sidan
            {
                try
                {
                    var member = Service.GetMember(Id);
                    if (member != null)
                    {
                        MemberName.Text = String.Format("{0} {1}", member.Fnamn, member.Enamn);
                        return;
                    }

                    // Hittade inte medlemmen.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Medlem nummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmen skulle tas bort");
                }

                // Döljer bekräftelsen samt deleteknappen
                ConfirmationPlaceHolder.Visible = false;
                DeleteLinkButton.Visible = false;
            }
        }


        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e) // Tar bort den medlemmen from databas 
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteMember(id);


                Page.SetTempData("SuccessMessage", "Medlemmen togs bort");// Sparar ett rättmeddelande i en temporär sessionsvariabel 
                Response.RedirectToRoute("Members", null); //dirigerar användaren till listan sidan med medlemmar
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmen skulle tas bort");
            }
        }
    }
}