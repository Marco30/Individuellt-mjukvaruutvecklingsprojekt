using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVT.Model;
using System.Data;

namespace MVT.Pages.MedlemsPages
{
    public partial class AktivitetMedlem : System.Web.UI.Page
    {
        // Privat fält för service-klass.
        private Service _service;

        // Egenskap som initializerar ett service-objekt ifall det inte redan finns något.
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Om genomförd handling lyckades av klienten och meddelande finns så visas det
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        public void MemberActivityFormView_InsertItem(MemberActivity memberActivity)
        {

            
            Service.ExisterarMedlemAktivitetInfo(memberActivity);

            if (memberActivity.Existerar==0)
            { 
                try
                {
                    Service.SaveMemberActivity(memberActivity);

                    // Sparar ett rättmeddelande i en temporär sessionsvariabel och dirigerar användaren till listan med medlemmar.
                    Page.SetTempData("SuccessMessage", "Medlem las till i aktiviteten!");
                    Response.RedirectToRoute("ActivityCreate", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmen skulle läggas till.");
                }

            }
            else
            {
                // Sparar ett rättmeddelande i en temporär sessionsvariabel och dirigerar användaren till listan med medlemmar.
                Page.SetTempData("SuccessMessage", "Medlem finns redan i aktivtet");
                Response.RedirectToRoute("ActivityCreate", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        
        }

        // Hämtar medlemmarna och lägger dem i dropdownlistan.
        public IEnumerable<Member> MemberDropDownList_GetData()
        {
            return Service.GetMembers();
        }
        
        // Hämtar aktiviteter och lägger dem i dropdownlistan.
        public IEnumerable<Activity> ActivityDropDownList_GetData()
        {
            return Service.GetActivities();
        }
    }
}