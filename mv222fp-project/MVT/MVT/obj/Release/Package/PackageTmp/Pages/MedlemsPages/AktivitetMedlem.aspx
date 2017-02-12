<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="AktivitetMedlem.aspx.cs" Inherits="MVT.Pages.MedlemsPages.AktivitetMedlem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">


    
     


        <div id="Menyram">

    <div id="TitleLabellist">
    <h1>
       Lägg till i aktivitet
    </h1>
        </div>
             

       <!--Meny länkar-->
    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
        <asp:HyperLink ID="HyperLink5" CssClass="alinks" runat="server" Text="Aktiviteter" NavigateUrl='<%$ RouteUrl:routename=Activities %>' />
        <asp:HyperLink ID="HyperLink7" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewActivities %>' Text="Lägg till ny aktivitet/redigera aktivitteter" />
    </div>
    </div>

    <div id="Kontak1">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Ett fel har inträffat. Korrigera felet och försök igen." />

    <asp:FormView ID="MemberActivityFormView" runat="server"
        ItemType="MVT.Model.MemberActivity"
        DefaultMode="Insert"
        RenderOuterTable="false"
        DataKeyNames="MedAktID, MedID, AktID"
        InsertMethod="MemberActivityFormView_InsertItem">
        <InsertItemTemplate>

            <div class="contentA1">
                <label for="Members">Välj medlem & aktivitet</label>
            </div>

            <div class="headerK">
                Medlem
                </div>

            <div class="contentA2">

                <%-- Lista med medlemmar --%>
                <asp:DropDownList ID="MemberDropDownList" runat="server"
                    ItemType="MVT.Model.Member"
                    SelectMethod="MemberDropDownList_GetData"
                    DataTextField="Fnamn"
                    DataValueField="MedID"
                    SelectedValue='<%# BindItem.MedID %>'></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="En medlem måste väljas!"
                    ControlToValidate="MemberDropDownList"
                    Display="None"></asp:RequiredFieldValidator>
                </div>

            <div class="headerK">
                Aktivitet
                </div>

            <div class="contentA2">

                <%-- Lista med aktiviteter --%>
                <asp:DropDownList ID="ActivityDropDownList" runat="server"
                    ItemType="MVT.Model.Activity"
                    SelectMethod="ActivityDropDownList_GetData"
                    DataTextField="AktTyp"
                    DataValueField="AktID"
                    SelectedValue='<%# BindItem.AktID %>'></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="En aktivitet måste väljas!"
                    ControlToValidate="ActivityDropDownList"
                    Display="None"></asp:RequiredFieldValidator>

            </div>

             <div class="headerK67">
                 <div class="men">
                <%-- "Kommandknappar" för att lägga till en ny kontaktuppgift och rensa texfälten --%>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Members", null) %>' />
                     </div>
            </div>

        </InsertItemTemplate>
    </asp:FormView>

         </div>

               <!-- Visar text meddelande om man lagg till medlem  -->
    <div id="text6in">
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />

         <div id="Button888in">
        <asp:Button ID="Button1" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>

    </asp:Panel>
          </div>

</asp:Content>
