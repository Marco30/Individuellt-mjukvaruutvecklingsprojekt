<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="MVT.Pages.MedlemsPages.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">

   

         <!-- Visar text meddelande om man tagit bort medlem  -->





        <!-- Visar fel medlande -->
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <div id="Menyram">



              <div id="TitleLabellist">
               
             <h1>
       Medlemsregister 
    </h1>
            </div>

        <!--Meny länkar-->
    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
        <asp:HyperLink ID="HyperLink1" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=MemberCreate %>' Text="Lägg till ny medlem" />
        <asp:HyperLink ID="HyperLink5" CssClass="alinks" runat="server" Text="Aktiviteter" NavigateUrl='<%$ RouteUrl:routename=Activities %>' />
        <asp:HyperLink ID="HyperLink6" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=ActivityCreate %>' Text="Lägg till medlem i aktivitet" />
        <asp:HyperLink ID="HyperLink7" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewActivities %>' Text="Lägg till ny aktivitet/redigera aktivitteter" />
        <asp:HyperLink ID="HyperLink4" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=Befattningar %>' Text="Befattningar" />

    </div>



         </div>

                    

    <div id="info">

        <!-- listeview som visar alla medlemar i databasen-->
    <asp:ListView ID="MemberListView" runat="server"
        ItemType="MVT.Model.Member"
        SelectMethod="MemberListView_GetData"
        DataKeyNames="MedID">

        <LayoutTemplate>
            <!-- Platshållare för medlemmar -->
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        
      
        
        <ItemTemplate>
            <dl>
                <dt id="header">
              
                 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MedID })  %>' Text='<%# Item.Fnamn + " " + Item.Enamn %> ' /></dt>

                <dd id="content1">
                   <%#: Item.Blevmedlem %>
                </dd>
                <dd id="content2">
                   <%#: Item.Befattningstyp %> 
                </dd>
            </dl>
        </ItemTemplate>

        
        <EmptyDataTemplate>
            <!-- Detta visas då medlemmar saknas i databasen. -->
            <p>
                Medlemmar saknas.
            </p>
        </EmptyDataTemplate>

    </asp:ListView>

    </div>   

                <div id="text6">
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
        <div id="Button88">
        <asp:Button ID="Button1" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
        </div>

</asp:Content>
