<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="Befattningar.aspx.cs" Inherits="MVT.Pages.MedlemsPages.Befattningar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">


   
    <div id="Menyram">

    <div id="TitleLabellist">
               
             <h1>
         Befattningar
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
   
     Lägg till Befattning
    </div>
    
             
<asp:FormView ID="InstrumentFormView" runat="server"
    ItemType="MVT.Model.Befattning"
    DataKeyNames="MedID"
    DefaultMode="Insert"
    InsertMethod="BefattningFormView_Insert"
    RenderOuterTable="false" 
    ViewStateMode="Enabled">

    <InsertItemTemplate>





             <div class="headerK">
                <label for="TextBox2">Befattning</label>
            </div>

             <div class="contentK">
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.Befattningstyp %>' MaxLength="25" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Befattning fältet ät tomt!"
                    ControlToValidate="TextBox2"
                    Display="None" ValidationGroup="new"></asp:RequiredFieldValidator>
            </div>

            <div class="headerK">
                <label for="TextBox3">Arvode</label>
            </div>

            <div class="contentK">
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.Arvode %>' MaxLength="25" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Arvode fältet ät tomt!"
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
   Befattningar
</div>
  
       <!-- ListView som presenterar alla Kontakter som kan redigeras. -->
         <!--DataKeyNames="KontaktID,MedID" används för att ta med ID som du hämtat ut frå databasen, in i C#-->
            <asp:ListView ID="BefattningListView" runat="server"
                ItemType="MVT.Model.Befattning"
                DataKeyNames="BefattningID"
                SelectMethod="BefattningListView_GetData"
                UpdateMethod="BefattningListView_Update"
                DeleteMethod="BefattningListView_Delete">
                
               

                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <p>
                        Har ingen BefattninInfo
                    </p>
                </EmptyDataTemplate>

               <ItemTemplate>


               <%-- Namn --%>
                <div class="section" >
                    <div class="left">
                        <span class="title">Befattning</span>

                            <asp:TextBox ID="Befattningstyp" runat="server" Text='<%# BindItem.Befattningstyp %>'  MaxLength="20" Width="150px" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Befattning får inte var tom när du ska uppdatera" ControlToValidate="Befattningstyp" Display="None" ></asp:RequiredFieldValidator>
                    </div>

                     <div class="left">
                        <span class="title1">Arvode</span>
                         <div class="arvodebox">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Arvode%>'  MaxLength="20" Width="150px" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Arvode får inte var tom när du ska uppdatera" ControlToValidate="TextBox1" Display="None"></asp:RequiredFieldValidator>
                         </div>
                              </div>
                   
                   <div id="sight1">

                     <!-- Redigera knapp -->
                     <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Update" Text="Uppdatera"  CssClass="button lessMargin" ValidationGroup="oldKontakter" />  
                       </div>

                        <div id="sight2">
                                  <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Delete" Text="Radera"  CssClass="button lessMargin" 
                                     OnClientClick='<%# String.Format("return confirm(\" VARNING: du kommer ta bort Befattning {0}!\")", Item.Befattningstyp) %>'/>  
                    </div>

                    </div>
                        <br />

                    

                     </ItemTemplate>                 
            </asp:ListView>

        </div>

          <div class="ValT2B">

           <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Följande fel inträffade:"  ValidationGroup="new"
            CssClass="validation-summary-errors"/>
              </div>

              <div class="ValT4B">
     <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="Följande fel inträffade"
                        CssClass="validation-summary-errors" ValidationGroup="oldKontakter" ShowModelStateErrors="False" />
    <br />
</div>

             <!-- Visar text meddelande om man lagg till medlem  -->
    <div id="text6bf">
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />

         <div id="Button88BEF">
        <asp:Button ID="Button1" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>

    </asp:Panel>
          </div>



</asp:Content>
