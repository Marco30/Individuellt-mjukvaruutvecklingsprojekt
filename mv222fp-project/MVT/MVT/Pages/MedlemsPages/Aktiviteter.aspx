<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="Aktiviteter.aspx.cs" Inherits="MVT.Pages.MedlemsPages.Aktiviteter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">



    
    <div id="Menyram">

    <div id="TitleLabellist">
               
             <h1>
          Aktiviteter
    </h1>
            </div>
    <!--Meny länkar-->



    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
        <asp:HyperLink ID="HyperLink6" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=ActivityCreate %>' Text="Lägg till medlem i aktivitet" />
        <asp:HyperLink ID="HyperLink7" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewActivities %>' Text="Lägg till ny aktivitet/redigera aktivitteter" />
    </div>

        </div>

         <div id="info13">

       <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:ListView ID="ActivityListView" runat="server"
        ItemType="MVT.Model.Activity"
        SelectMethod="ActivityListView_GetData"
        DataKeyNames="AktID">
        <LayoutTemplate>
            <%-- Platshållare för medlemmar --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt class="header13">
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# GetRouteUrl("ActivityDetails", new { id = Item.AktID })  %>' Text='<%# Item.Akttyp %> ' />
                </dt>
                   <dd id="content12">
                    Startdatum:
                    <%#: Item.Startdatum%>

                   
                </dd>
                <dd id="content23">
                    Slutdatum:
                    <%#: Item.Slutdatum  %> 

                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då aktiviteter saknas i databasen. --%>
            <p>
                Aktiviteter saknas.
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
