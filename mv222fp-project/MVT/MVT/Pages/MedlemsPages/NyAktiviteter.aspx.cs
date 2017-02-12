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
    public partial class NyAktiviteter : System.Web.UI.Page
    {

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            // Visar eventuella meddelanden lagrade i de temporära sessionsvariablerna.
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        // skappa ny aktivitet

        public void Button1_Click(object sender, EventArgs e)
        {
            if(Calendar2.Visible == true)
            {
                Calendar2.Visible = false;
                Button2.Visible = true;
              
            }

            Calendar1.Visible = true;
            Button1.Visible = false;


        }

        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            Button1.Visible = true;

        }
         
        
        public void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == true)
            {
                Calendar1.Visible = false;
                Button1.Visible = true;
            }
            Calendar2.Visible = true;
            Button2.Visible = false;
        }

        public void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
            Button2.Visible = true;

        }



        public void Button3_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
               try
                {
                    Activity A = new Activity();
                    A.Akttyp = TextBox2.Text;
                    A.Startdatum = TextBox1.Text;
                    A.Slutdatum = TextBox3.Text;


                    Service.AddAktivitetInfo(A);

                    //Laddar om sidan
                    Page.SetTempData("SuccessMessage", "Aktivitet har lagts till!!");
                    Response.RedirectToRoute("NewActivities", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då medlemmarna skulle hämtas från databasen.");
                }
            }
        }

        //-------------------------
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

        // updaterar aktivtet
        public void ActivityListView_Update(Activity K)
        {


            if (ModelState.IsValid)
            {

                try
                {


                    Service.UpdateActivityInfo(K);

                    //Laddar om sidan
                    Page.SetTempData("SuccessMessage", "Aktivitet har updaterats!!");
                    Response.RedirectToRoute("NewActivities", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då aktivitet skulle uppdateras ");
                }

            }
        }

        // tar bort aktivitet
        public void ActivityListView_Delete(Activity K)
        {


            try
            {


                Service.DeletActivitytInfo(K);

                //Laddar om sidan
                Response.RedirectToRoute("NewActivities", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kontak skulle tasbort");
            }

        }



    }
}