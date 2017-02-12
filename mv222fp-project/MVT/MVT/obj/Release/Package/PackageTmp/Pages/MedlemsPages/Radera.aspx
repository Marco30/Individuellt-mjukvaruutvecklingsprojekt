<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="Radera.aspx.cs" Inherits="MVT.Pages.MedlemsPages.Radera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    


         <div id="Menyram">

    <div id="TitleLabellist">
               
             <h1>
       Ta bort medlem
    </h1>
            </div>

    

        <!--Meny länkar-->
    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
    </div>

          </div>

     <div id="Selectedbort">

    <!-- Visar fel medlande visas här -->
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <!--För bekräftelse om att ta bort användare  -->
         <div class="headerbort">
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort <strong>
                <asp:Literal runat="server" ID="MemberName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
             </div>

    <div class="contentbort">

        <div id="borttext1">
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort medlemmen"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
             </div>

            <div id="borttext2">
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
                 </div>
    </div>

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
