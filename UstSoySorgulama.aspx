<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UstSoySorgulama.aspx.cs" Inherits="UstSoySorgula.UstSoySorgulama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             
            
           
           
           
            
           <h4> ÜST SOY SORGULA </h4>
    
              <br />
              <br />
    
            
    
              <asp:Table ID="Table1" runat="server" Height="185px" Width="574px">
                  <asp:TableRow runat="server">
                      <asp:TableCell runat="server">
                          <asp:Label ID="Label1" runat="server" Text="Tc Kimlik Numarası : " > </asp:Label>
                          </asp:TableCell>
                      <asp:TableCell runat="server"> 
                          <asp:TextBox ID="txtTcKimlikNo" runat="server" MaxLength="11"></asp:TextBox>
                              </asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                      <asp:TableCell runat="server">   <asp:Label ID="Label2" runat="server" Text="Adınız : "> </asp:Label> </asp:TableCell>
                      <asp:TableCell runat="server"> <asp:TextBox ID="txtAd" runat="server"></asp:TextBox></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                       <asp:TableCell runat="server">   <asp:Label ID="Label3" runat="server" Text="Soyadını : "> </asp:Label> </asp:TableCell>
                      <asp:TableCell runat="server"> <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox></asp:TableCell>
                   
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                      <asp:TableCell runat="server"> <asp:Label ID="Label4" runat="server" Text="Dogum Yiliniz : "> </asp:Label> </asp:TableCell>
                      <asp:TableCell runat="server"> <asp:TextBox ID="txtDogumYili" runat="server" MaxLength="4"></asp:TextBox></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                      <asp:TableCell runat="server"></asp:TableCell>
                      <asp:TableCell runat="server"><asp:Button ID="BtnSorgula" runat="server" Text="Sorgula" OnClick="Sorgula_Click" Width="126px" /></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                      <asp:TableCell runat="server"> <asp:Label ID="Label5" runat="server" > </asp:Label> </asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                       <asp:TableCell runat="server"> <asp:Label ID="Label7" runat="server" > </asp:Label> </asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow runat="server">
                  </asp:TableRow>
              </asp:Table>

            


             <br />
              <br />
              <asp:Label ID="Label6" runat="server" Text="MERVE AYDIN ASP.NET EĞİTİM" > </asp:Label>

        </div>
    </form>
</body>
</html>
