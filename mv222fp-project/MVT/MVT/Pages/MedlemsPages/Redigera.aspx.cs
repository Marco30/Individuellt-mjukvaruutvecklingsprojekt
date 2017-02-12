using System;
using System.Web.ModelBinding;
using System.Web.UI;
using MVT.Model;
using System.Collections.Generic;

namespace MVT.Pages.MedlemsPages
{
    public partial class Redigera : System.Web.UI.Page
    {

        private Service _service;// Privat fält för service-klass


        private Service Service// Egenskap som initializerar/skapar ett service-objekt om det inte redan fin en 
        {
            get { return _service ?? (_service = new Service()); }
        }

        // Hämtar den valda medlemmen.
        public MVT.Model.Member MemberFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetMember(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmen skulle hämtas vid uppdatering.");
                return null;
            }
        }


        public void MemberFormView_UpdateItem(int medId) // id parameternamn ska matcha Medlem som ska updateras 
        {
            try
            {
                var member = Service.GetMember(medId);
                if (member == null)
                {
                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Medlemmen nummer {0} hittades inte.", medId));
                    return;
                }

                if (TryUpdateModel(member))
                {
                    // Sparar ett rättmeddelande i en temporär sessionsvariabel och dirigerar användaren till listan med medlemmar.
                    Service.SaveMember(member);
                    Page.SetTempData("SuccessMessage", "Medlem har Redigerats!!");
                    Response.RedirectToRoute("MemberDetails", new { id = member.MedID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då medlemmen skulle uppdateras.");
            }
        }


        public IEnumerable<Befattning> BefattningstypTypeDropDownList_GetData()
        {

            return Service.GetBefattningTypes();
        }

    }
}