<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="AktiviteterInfo.aspx.cs" Inherits="MVT.Pages.MedlemsPages.AktiviteterInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">

  
>
    
    <div class="Menyram88">

    <div id="TitleLabellist">
               
             <h1>
          Redigera Medlemar i aktivitet
    </h1>
            </div>
    <!--Meny länkar-->



    <div id="Meny">
        <asp:HyperLink ID="HyperLink1" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
        <asp:HyperLink ID="HyperLink4" CssClass="alinks" runat="server" Text="Aktiviteter" NavigateUrl='<%$ RouteUrl:routename=Activities %>' />
        <asp:HyperLink ID="HyperLink6" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=ActivityCreate %>' Text="Lägg till medlem i aktivitet" />
        <asp:HyperLink ID="HyperLink7" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewActivities %>' Text="Lägg till ny aktivitet/redigera aktivitteter" />
    </div>

         </div>

     <div id="Kontak1">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:ListView ID="ActivityTypeListView" runat="server"
        ItemType="MVT.Model.ActivityType"
        SelectMethod="ActivityTypeListView_GetData"
        DeleteMethod="Person_Delete"
        DataKeyNames="AktID,MedID">
        <LayoutTemplate>
            <%-- Platshållare för medlemmar --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt class="headerK">
                    <asp:Label ID="Label1" runat="server" Text='<%# Item.Fnamn + " " + Item.Enamn %> '></asp:Label>
                </dt>
                <dt class="contentA2">
                   Registrerad på aktivtet: <%#: Item.Registrerad %>
                </dt>

                <dt class="headerK68">
                    <div class="men">
                    <%-- "Kommandknapp" för att ta bort medlem från aktiviteten --%>
                                  <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Delete" Text="Ta Bort"  CssClass="button lessMargin" 
                                     OnClientClick='<%# String.Format("return confirm(\" VARNING: du kommer ta bort {0} från aktivtet !\")", Item.Fnamn + " " + Item.Enamn) %>'/>  
                    </div>
                        </dt>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då medlemmar saknas i databasen. --%>
            <p class="headerK">
                Medlemmar saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>

</div>

       <div id="text6R">
     <!-- Visar text meddelande om att man lag till medlem -->
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />

         <div id="Button88R">
        <asp:Button ID="Button2" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
        </div>

</asp:Content>
