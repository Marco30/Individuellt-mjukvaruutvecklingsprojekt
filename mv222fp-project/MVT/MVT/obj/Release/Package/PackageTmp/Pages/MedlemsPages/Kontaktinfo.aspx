<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="Kontaktinfo.aspx.cs" Inherits="MVT.Pages.MedlemsPages.Kontaktinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    
  




    <div id="Menyram">

    <div id="TitleLabellist">
               
             <h1>
          Redigera Kontaktinformation 
    </h1>
            </div>
    <!--Meny länkar-->



    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
    </div>

           </div>
    
     <div id="Kontak1">

     <div class="contentK1">
       <!-- läger till kontaktinfromation -->   
   
     Lägg till kontaktinformation
    </div>
             
<asp:FormView ID="InstrumentFormView" runat="server"
    ItemType="MVT.Model.KontaktTyp"
    DataKeyNames="MedID"
    DefaultMode="Insert"
    InsertMethod="kontaktFormView_Insert"
    RenderOuterTable="false" 
    ViewStateMode="Enabled">

    <InsertItemTemplate>

                <div class="headerK"><!-- Dropdownlist Kontakttyp -->
                <label for="AddTypeDropDownList">Kontakttyp</label>
                </div>

         <div class="contentK">
                <asp:DropDownList ID="AddTypeDropDownList" runat="server"                    
                    SelectMethod="KategoriTypeDropDownList_GetData"
                    DataTextField="Kontakttyp"
                    DataValueField="KontakttypID"
                    SelectedValue='<%# BindItem.KontakttypID %>'/>

              </div>

             <div class="headerK">
                <label for="TextBox2">Kontaktuppgift</label>
            </div>

            <div class="contentK">
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.Kontaktuppgift %>' MaxLength="30" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Kontaktuppgift fältet ät tomt!"
                    ControlToValidate="TextBox2"
                    Display="None" ValidationGroup="new"></asp:RequiredFieldValidator>
            </div>



    <div class="headerK">
      <asp:Button ID="SaveButton" runat="server" Text="Lägg till" CommandName="Insert" ValidationGroup="new" CssClass="button lessMargin"/>
        </div>

        <br />

       </InsertItemTemplate>
      </asp:FormView>

        </div>

        



    <!-- alla här upp funkar bra nu, vi fixar det här ner nu-->
    <div id="Kontak2">

        
    <div id="KontakT2">


      <!-- Redigerar till kontaktinfo -->
   kontaktinformation
</div>

  
       <!-- ListView som presenterar alla Kontakter som kan redigeras. -->
         <!--DataKeyNames="KontaktID,MedID" används för att ta med ID som du hämtat ut frå databasen, in i C#-->
            <asp:ListView ID="kontaktListView" runat="server"
                ItemType="MVT.Model.KontaktTyp"
                DataKeyNames="KontaktID,MedID"
                SelectMethod="kontaktListView_GetData"
                UpdateMethod="kontaktListView_Update"
                DeleteMethod="kontaktListView_Delete">
            

                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p class="headerK08">
                        Har ingen kontaktinfo
                    </p>
                </EmptyDataTemplate>

               <ItemTemplate>


               <%-- Namn --%>
                <div class="section" >
                    <div class="left">
                        <span class="title"><%#: Item.Kontakttyp %> </span>
                        
                        <div class="M1">
                            <asp:TextBox ID="Kontaktuppgift" runat="server" Text='<%# BindItem.Kontaktuppgift %>'  MaxLength="30"  />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Kontaktuppgift får inte var tom när du ska uppdatera" ControlToValidate="Kontaktuppgift" Display="None"></asp:RequiredFieldValidator>
                    </div>

                             </div>
                   
                   <div id="sight1">

                     <!-- Redigera knapp -->
                     <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Update" Text="Uppdatera"  CssClass="button lessMargin" ValidationGroup="oldKontakter" />  
                       </div>

                        <div id="sight2">
                                  <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Delete" Text="Radera"  CssClass="button lessMargin" 
                                     OnClientClick='<%# String.Format("return confirm(\" VARNING: du kommer ta bort Kontaktuppgift {0}!\")", Item.Kontakttyp) %>'/>  
                    </div>

                    </div>
                        <br />

                    

                     </ItemTemplate>                 
            </asp:ListView>

        


        <div id="Ktilbaka">
        <!-- Tillbakaknapp -->
          
       <asp:FormView ID="MemberFormView" runat="server"
        ItemType="MVT.Model.Member"
        SelectMethod="MemberFormView_GetItem"
        RenderOuterTable="false">

        <ItemTemplate>
              <asp:HyperLink ID="HyperLink" runat="server" Text="Tillbaka till Medlem" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MedID }) %>' />
        </ItemTemplate>

        </asp:FormView>

      </div>

        
          <!-- Visar text meddelande om man lagg till medlem  -->
    <div id="text4K">
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
         <div id="Button88K">
        <asp:Button ID="Button1" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
          </div>

        </div>

     <div class="ValT2">

           <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Följande fel inträffade:"  ValidationGroup="new"
            CssClass="validation-summary-errors"/>
   </div>

         <div class="ValT4K">
     <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="Följande fel inträffade"
                        CssClass="validation-summary-errors" ValidationGroup="oldKontakter" ShowModelStateErrors="False" />
</div>

    
            <div class="text6">
     <!-- Visar text meddelande om att man lag till medlem -->
    <asp:Panel runat="server" ID="Panel1" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="Literal1" />
         <div id="Button881">
        <asp:Button ID="Button2" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
        </div>



</asp:Content>

