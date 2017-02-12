<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="MedlemsInfo.aspx.cs" Inherits="MVT.Pages.MedlemsPages.MedlemsInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">




    <div id="Menyram">

    <div id="TitleLabellist">
     <h1>
        Medlem
    </h1>
</div>



     <!--Meny länkar-->
    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
    </div>

          </div>


     <div id="S1">

   
     <!-- Visar fel medlande visas här -->
     <!-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" /> -->

    <!-- formview som visar detaljerad medlems information från databasen-->
    <asp:FormView ID="MemberFormView" runat="server"
        ItemType="MVT.Model.Member"
        SelectMethod="MemberFormView_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>

            <div class="header">
                <label for="Name">Förnamn</label>
            </div>
            <div class="content">
                <%#: Item.Fnamn %>
            </div>

                        <div class="header">
                <label for="Name">Efternamn</label>
            </div>
            <div class="content">
                <%#: Item.Enamn %>
            </div>


            <div class="header">
                <label for="CivicRegistrationNumber">Personnummer</label>
            </div>
            <div class="content">
                <%#: Item.PersNR %>
            </div>

            <div class="header">
                <label for="Region">Ort</label>
            </div>
            <div class="content">
                <%#: Item.Ort %>
            </div>

            <div class="header">
                <label for="Address">Adress</label>
            </div>
            <div class="content">
                <%#: Item.Address %>
            </div>

            <div class="header">
                <label for="Region">Blevmedlem</label>
            </div>
            <div class="content">
                <%#: Item.Blevmedlem %>
            </div>

      
            <!--Meny länkar-->
            <div id="slut">
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("MemberEdit", new { id = Item.MedID }) %>' />
                <asp:HyperLink ID="HyperLink4" runat="server" Text="KontaktInfo" NavigateUrl='<%# GetRouteUrl("Memberkontakt", new { id = Item.MedID }) %>' />
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("MemberDelete", new { id = Item.MedID }) %>' />
            </div>
              
        </ItemTemplate>
    </asp:FormView>


             <!--BID-->

    <asp:ListView ID="BefattningListView" runat="server"
                ItemType="MVT.Model.Befattning"
                DataKeyNames="MedID"
                SelectMethod="BefattningListView_GetData">
                

                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    
                </LayoutTemplate>

                <EmptyDataTemplate>
                    <div id="ingen">
                        Har ingen Befattningstyp
                        </div>
                </EmptyDataTemplate>

               <ItemTemplate>

           
               <!-- Befattning -->
                
                      
                    <div id="befattning">
                        <div id="b1">Befattningstyp</div>
                        <dive id="title"><%#: Item.Befattningstyp %> </dive>
                           <dive id="arvode">
                          <div id="b2">Arvode</div>
                    <dive id="title2"> <%#: Item.Arvode %> </dive>
                </dive>
               
                    </div>

                        <br />

                     </ItemTemplate>                 
            </asp:ListView>


         <!--Slut B-->

           </div>

         <div id="Selected2">

          <asp:ListView ID="KontaktListVieww" runat="server"
        ItemType="MVT.Model.KontaktTyp"
        SelectMethod="kontaktListView_GetData"
        DataKeyNames="MedID">

        <LayoutTemplate>
            <!-- Platshållare för Kontaktuppgifter -->
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </LayoutTemplate>

        <ItemTemplate>
            <dl>
                <dt id="headerK">
                    <label for="Kontaktuppgifter">Kontaktuppgifter</label>
                </dt>
                <dd id="contentK1">
                    <%#: Item.Kontakttyp %>
                </dd>
                <dd id="contentK2">
                    <%#: Item.Kontaktuppgift  %>
                </dd>
            </dl>
        </ItemTemplate>

        <EmptyDataTemplate>
            <%-- Detta visas då Kontaktuppgifter saknas i databasen --%>
            <p class="headerK07">
                Kontaktuppgifter Saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
           
  </div> 

       <div id="Selected3">

          <asp:ListView ID="ListView1" runat="server"
        ItemType="MVT.Model.ActivityType"
        SelectMethod="MedlemDeltarAktiviteter_GetData"
        DataKeyNames="AktID">

        <LayoutTemplate>
            <!-- Platshållare för Kontaktuppgifter -->
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </LayoutTemplate>

        <ItemTemplate>
            <dl>
                 <dt id="headeA">
                   Deltar i Aktivtet
                </dt>
                <dt id="contentA1">
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# GetRouteUrl("ActivityDetails", new { id = Item.AktID })  %>' Text='<%# Item.Akttyp %> ' />
                </dt>
            </dl>
        </ItemTemplate>

        <EmptyDataTemplate>
            <%-- Detta visas då Kontaktuppgifter saknas i databasen --%>
            <p id="headeA">
                 Är inte med i någon aktivitet
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
           
   </div>

             

                <div id="text6">
     <!-- Visar text meddelande om att man lag till medlem -->
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
          <div id="Button88">
        <asp:Button ID="Button1" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
        </div>

</asp:Content>
