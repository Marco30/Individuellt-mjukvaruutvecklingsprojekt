using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data.SqlClient;
using System.Configuration;
using MVT.Model;

namespace MVT.Pages.MedlemsPages
{
    public partial class Kontaktinfo : System.Web.UI.Page
    {


        private Service _service;
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

        // får drop down box info
        public IEnumerable<KontaktTyp> KategoriTypeDropDownList_GetData()
        {

            return Service.GetKontaktTypes();
        }

        // lägger till kontaktinfo
      

        public void kontaktFormView_Insert([RouteData] int id, KontaktTyp K)
        {
            try
            {
                K.MedID = id;
                Service.AddKontaktInfo(K);

                //Laddar om sidan
                Page.SetTempData("SuccessMessage", "Kontaktinformation har lagts till!!");
                Response.RedirectToRoute("Memberkontakt", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmarna skulle hämtas från databasen.");
            }

        }
     
        // Ladar ner alla info 
        public IEnumerable<MVT.Model.KontaktTyp> kontaktListView_GetData([RouteData] int id)
        {
            try
            {

                return Service.GetMemberKontaktTinfo(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmarna skulle hämtas från databasen.");
                return null;
            }

        }

        // updaterar kontakt
        public void kontaktListView_Update(KontaktTyp K)
        {

              

            if (ModelState.IsValid)
            {

                try
                {


                    Service.UpdateKontaktInfo(K);

                    //Laddar om sidan
                    Page.SetTempData("SuccessMessage", "Kontaktinformation har updaterats!!");
                    Response.RedirectToRoute("Memberkontakt", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kontak skulle uppdateras ");
                }

            }
        }

        public void kontaktListView_Delete(KontaktTyp K)
        {


            try
            {


                Service.DeletKontaktInfo(K);

                //Laddar om sidan
                Response.RedirectToRoute("Memberkontakt", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kontak skulle tasbort");
            }

        }

        //använda för att få MedlemsID till länken som tar oss till baks till medlem
        public MVT.Model.Member MemberFormView_GetItem([RouteData] int id)
        {
            try
            {

                return Service.GetMember(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmen hämtades.");
                return null;
            }
        }

    }
}