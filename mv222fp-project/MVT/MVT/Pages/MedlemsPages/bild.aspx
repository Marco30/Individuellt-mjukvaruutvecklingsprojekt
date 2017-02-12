<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Delade/Site.Master" AutoEventWireup="true" CodeBehind="bild.aspx.cs" Inherits="MVT.Pages.MedlemsPages.bild" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">

       <asp:ValidationSummary
         runat="server" 
        CssClass="validation-summary-errors"
        ValidationGroup="ProductUpload" ID="Validation" />

    <asp:FormView ID="ProductFormView" runat="server"
        ItemType="MVT.Model.ImageTyp"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="ProductFormView_InsertItem" >
        <InsertItemTemplate>

          
            <div class="editor-field">
                <div class="editor-label">
                    <label for="AddImage">Bild</label>
                </div>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett bildnamn måste anges." ControlToValidate="AddImage" ValidationGroup="ProductUpload"></asp:RequiredFieldValidator>
                <asp:TextBox ID="AddImage" runat="server" Text='<%# BindItem.ImageAdres %>' Enabled="false" MaxLength="50" />
            </div>




              <div>
                <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
            </div>
        </InsertItemTemplate>
        
    </asp:FormView>
    <%-- Uploading of images --%>
            <asp:Panel ID="UploadPanel" runat="server"> 
      
            <asp:ValidationSummary 
                ID="ValidationSummary1" 
                ValidationGroup="ImageUpload"
                runat="server" />  
            <asp:FileUpload ID="FileUpload" runat="server" />
       
             <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server" 
                ErrorMessage="En fil måste finns" 
                ControlToValidate="FileUpload" 
                Display="None"
                ValidationGroup="ImageUpload">
            </asp:RequiredFieldValidator>
       
            <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" 
                runat="server" 
                ErrorMessage="Endast bilder av typerna gif, jpeg eller png är tillåtna." 
                ControlToValidate="FileUpload" 
                ValidationExpression='.*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])' 
                Display="None" 
                ValidationGroup="ImageUpload"></asp:RegularExpressionValidator>
            <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
        </asp:Panel>
<%-- Uploading of images END --%>


</asp:Content>
