<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="NyAktiviteter.aspx.cs" Inherits="MVT.Pages.MedlemsPages.NyAktiviteter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">


   



         <div id="Menyram">

    <div id="TitleLabellist">
               
             <h1>
       Redigera aktivitteter
    </h1>
            </div>

    

        <!--Meny länkar-->
    <div id="Meny">
        <asp:HyperLink ID="HyperLink3" CssClass="alinks" runat="server" Text="Hem" NavigateUrl='<%$ RouteUrl:routename=Members %>' />
                <asp:HyperLink ID="HyperLink5" CssClass="alinks" runat="server" Text="Aktiviteter" NavigateUrl='<%$ RouteUrl:routename=Activities %>' />
        <asp:HyperLink ID="HyperLink6" CssClass="alinks" runat="server" NavigateUrl='<%$ RouteUrl:routename=ActivityCreate %>' Text="Lägg till medlem i aktivitet" />
    </div>
</div>
     <div id="Kontak1">

   <div class="contentA1">
        Lägg till  Aktivtet
       </div>

       <div class="headerK">
    Aktivitet 
        </div>

            <div class="contentA2">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Aktivitet fältet ät tomt!"
                    ControlToValidate="TextBox2"
                    Display="None" ValidationGroup="new"></asp:RequiredFieldValidator>
            </div>

   <div class="headerA2">
 Datum för Aktivitet 
        </div>
            
         <div class="contentTid">

    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False">
        <DayStyle ForeColor="#00C5EF" />
        <NextPrevStyle ForeColor="White" />
             </asp:Calendar>
    <asp:Button ID="Button1" runat="server" Text="Datum" OnClick="Button1_Click" style="height: 26px" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Start Datum fältet ät tomt!"
                    ControlToValidate="TextBox1"
                    Display="None" ValidationGroup="new"></asp:RequiredFieldValidator>
        </div>

           <div class="headerA2">
 Slut Datum för Aktivitet 
                </div>

                    <div class="contentTid">
    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False" ForeColor="#00C5EF">
        <NextPrevStyle ForeColor="White" />
                        </asp:Calendar>
    <asp:Button ID="Button2" runat="server" Text="Datum" OnClick="Button2_Click" style="height: 26px" />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="slut datum fältet ät tomt!"
                    ControlToValidate="TextBox3"
                    Display="None" ValidationGroup="new"></asp:RequiredFieldValidator>
</div>

         <div class="contentA1">
    <asp:Button ID="Button3" runat="server" Text="Lägg till ny Aktivitet" ValidationGroup="new"  OnClick="Button3_Click" />
             </div>
</div>

    <!-- alla här upp funkar bra nu, vi fixar det här ner nu-->
    <div id="Kontak2A">
  
       <!-- ListView som presenterar alla Kontakter som kan redigeras. -->
         <!--DataKeyNames="KontaktID,MedID" används för att ta med ID som du hämtat ut frå databasen, in i C#-->
            <asp:ListView ID="ActivityListView" runat="server"
                ItemType="MVT.Model.Activity"
                DataKeyNames="AktID"
                SelectMethod="ActivityListView_GetData"
                UpdateMethod="ActivityListView_Update"
                DeleteMethod="ActivityListView_Delete">
                
               

                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    
                </LayoutTemplate>
               <ItemTemplate>

                       <div class="left2">
                        <div class="title88">Aktivitet:</div>

                            <div class="textA1">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Akttyp%>'  MaxLength="20" Width="150px" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Aktivitet får inte var tom när du ska uppdatera" ControlToValidate="TextBox1" Display="None"></asp:RequiredFieldValidator>
                        </div>
                                 </div>
     
                   <div id="contentA34">

                           <div class="title89">Startdatum:</div>

                       <div class="textA2">
                     
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%#: BindItem.Startdatum%>'  MaxLength="20" Width="150px" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Startdatum får inte var tom när du ska uppdatera" ControlToValidate="TextBox4" Display="None"></asp:RequiredFieldValidator>
                </div>
                       </div>

                 <div id="contentA33">

                     <div class="title90">Slutdatum:</div>

                     <div class="textA3">
                        
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%#: BindItem.Slutdatum  %>'  MaxLength="20" Width="150px" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="oldKontakter"
                                ErrorMessage="Slutdatum får inte var tom när du ska uppdatera" ControlToValidate="TextBox5" Display="None"></asp:RequiredFieldValidator>
               </div>
                     </div>

                     <div id="sight1A">

                     <!-- Redigera knapp -->
                     <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Update" Text="Uppdatera"  CssClass="button lessMargin" ValidationGroup="oldKontakter" />  
                       </div>

                        <div id="sight2A">
                                  <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Delete" Text="Radera"  CssClass="button lessMargin" 
                                     OnClientClick='<%# String.Format("return confirm(\" VARNING: du kommer ta bort aktivitet {0}!\")", Item.Akttyp) %>'/>  
                    </div>

        </ItemTemplate>

        <EmptyDataTemplate>
            <%-- Detta visas då aktiviteter saknas i databasen. --%>
            <p>
                Aktiviteter saknas.
            </p>
        </EmptyDataTemplate>

            </asp:ListView>

        </div>

          <div class="ValT2Ny">

           <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Följande fel inträffade:"  ValidationGroup="new"
            CssClass="validation-summary-errors"/>
               </div>

              <div class="ValT4Ny">
              <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="Följande fel inträffade"
                        CssClass="validation-summary-errors" ValidationGroup="oldKontakter" ShowModelStateErrors="False" />
    <br />
</div>

    
              <!-- Visar text meddelande om man lagg till medlem  -->
    <div id="text6Ny">
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
          <div id="Button88ny">
        <asp:Button ID="Button4" CssClass="exit" runat="server" Text="Stäng" OnClientClick="exitbutton_OnClick" />
            </div>
    </asp:Panel>
          </div>

</asp:Content>
