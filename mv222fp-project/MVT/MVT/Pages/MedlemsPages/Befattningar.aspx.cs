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
    public partial class Befattningar : System.Web.UI.Page
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

        // lägger till kontaktinfo
      

        public void BefattningFormView_Insert(Befattning B)
        {
            try
            {

                Service.AddBefattningInfo(B);

                //Laddar om sidan
                Page.SetTempData("SuccessMessage", "Befattningn har lagts till!!");
                Response.RedirectToRoute("Befattningar", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Befattning skulle läggas till");
            }

        }
     


        // Ladar ner alla info 

        public IEnumerable<Befattning> BefattningListView_GetData(Befattning B)
        {

            try
            {

                return Service.GetBefattningData(B);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Befattning skulle hämtas från databasen.");
                return null;
            }

        }

        // updaterar kontakt
        public void BefattningListView_Update(Befattning B)
        {
            if (ModelState.IsValid)
            {

                try
                {


                    Service.UpdateBefattning(B);

                    //Laddar om sidan
                    Page.SetTempData("SuccessMessage", "Befattning har updaterats!!");
                    Response.RedirectToRoute("Befattningar", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kontak skulle uppdateras ");
                }

            }
        }

        public void BefattningListView_Delete(Befattning B)
        {


            try
            {


                Service.DeleteBefattning(B);

                //Laddar om sidan
                Response.RedirectToRoute("Befattningar", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Befattningar skulle tasbort/ någon eller några melemdar har befatningen man vill ta bort");
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