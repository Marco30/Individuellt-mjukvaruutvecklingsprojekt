using System.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MVT// Marco Villegas
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)// Bestämmer vägarnaför de olika sidorna
        {
            routes.MapPageRoute("Members", "medlemmar", "~/Pages/MedlemsPages/Lista.aspx");
            routes.MapPageRoute("MemberCreate", "medlemmar/ny", "~/Pages/MedlemsPages/NyMedlem.aspx");
            routes.MapPageRoute("MemberDetails", "medlemmar/{id}", "~/Pages/MedlemsPages/MedlemsInfo.aspx");
            routes.MapPageRoute("MemberEdit", "medlemmar/{id}/redigera", "~/Pages/MedlemsPages/Redigera.aspx");
            routes.MapPageRoute("MemberDelete", "medlemmar/{id}/tabort", "~/Pages/MedlemsPages/Radera.aspx");
            routes.MapPageRoute("Error", "serverfel", "~/Pages/Delade/Error.html");
            routes.MapPageRoute("Default", "", "~/Pages/MedlemsPages/Lista.aspx");
            routes.MapPageRoute("Memberkontakt", "medlemmar/{id}/Kontaktinfo", "~/Pages/MedlemsPages/Kontaktinfo.aspx");
            routes.MapPageRoute("Befattningar", "Befattningar", "~/Pages/MedlemsPages/Befattningar.aspx");

            routes.MapPageRoute("NewActivities", "NyAktiviteter", "~/Pages/MedlemsPages/NyAktiviteter.aspx");
            routes.MapPageRoute("Activities", "aktiviteter", "~/Pages/MedlemsPages/Aktiviteter.aspx");
            routes.MapPageRoute("ActivityCreate", "aktiviteter/ny", "~/Pages/MedlemsPages/AktivitetMedlem.aspx");
            routes.MapPageRoute("ActivityDetails", "aktiviteter/{id}", "~/Pages/MedlemsPages/AktiviteterInfo.aspx");
            routes.MapPageRoute("ActivityEdit", "aktiviteter/{id}/redigera", "~/Pages/MedlemsPages/ActivityEdit.aspx");
            routes.MapPageRoute("ActivityDelete", "aktiviteter/{id}/tabort", "~/Pages/MedlemsPages/ActivityDelete.aspx");
        }
    }
}