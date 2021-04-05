using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UstSoySorgula
{
    public partial class UstSoySorgulama : System.Web.UI.Page
    {
        public int MaxLength { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //private void TxtTcKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        //}

        protected void Sorgula_Click(object sender, EventArgs e)
        {
            if (txtTcKimlikNo.Text == "")
            {
                Label5.Text = ("Tc Kimlik Numarası Giriniz !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtTcKimlikNo.Focus();
            }
            
            else if (txtTcKimlikNo.Text.Length < 11)
            {
                Label5.Text = ("HATALI  TC KİMLİK NUMARASI !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtTcKimlikNo.Focus();

            }
           
            else if (txtAd.Text == "")
            {
                Label5.Text = ("Adınızı  Giriniz !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtAd.Focus();



            }

            else if (txtSoyad.Text == "")
            {
                Label5.Text = ("Soyadınızı  Giriniz !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtSoyad.Focus();


            }
            else if (txtDogumYili.Text == "")
            {
                Label5.Text = ("Doğum yılınızı  Giriniz !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtDogumYili.Focus();



            }
            else if (txtDogumYili.Text.Length < 4 )
            {
                Label5.Text = ("HATALI DOĞUM YILI !! ");
                Label5.ForeColor = System.Drawing.Color.Red;
                txtDogumYili.Focus();



            }



            else
            {
                // ilk 4 haneyi alıp 3 ile toplama
                String tcKimlikNO = txtTcKimlikNo.Text; ;
                char[] ayir = new char[11];
                ayir = tcKimlikNO.ToCharArray();
                
                 string stepOne = ayir[0].ToString() + ayir[1].ToString() + ayir[3].ToString() + ayir[3].ToString() + ayir[4].ToString();               
                int x = Int32.Parse(stepOne);
                int StepOne = x + 3;
               



                // sonraki 4 haneden 1 çıkarma
                string StepTwoEkle = ayir[5].ToString() + ayir[6].ToString() + ayir[7].ToString() + ayir[8].ToString();
                int y = Int32.Parse(StepTwoEkle);
                int StepTwo = y - 1; 
                
                // son rakamdan 4 çıkartma
                string tckimlikNoYeni;
                string tcsonRakam = ayir[10].ToString();
                int sonrakam = Int32.Parse(tcsonRakam);
                int StepThree = 0;

                if (sonrakam < 4)

                {
                    string sonRakaminBasina1Ekle = "1" + tcsonRakam;
                    /// Response.Write(" son rakama 1 +  " + sonRakaminBasina1Ekle + "</br>");
                    StepThree = Int32.Parse(sonRakaminBasina1Ekle) - 4;
                    ///  Response.Write(" son rakama 2 +  " + z);

                    tckimlikNoYeni = Convert.ToString(StepOne) + Convert.ToString(StepTwo) + Convert.ToString(StepThree);
                    /// Response.Write("tc  " + tckimlikNoYeni + "</br>");

                }
                else

                {
                    string sonRakaminBasina1Ekle = tcsonRakam;
                    StepThree = Int32.Parse(sonRakaminBasina1Ekle) - 4;
                    //  Response.Write(" son rakama 2 +  " + z + "</br>");
                    tckimlikNoYeni = Convert.ToString(StepOne) + Convert.ToString(StepTwo) + Convert.ToString(StepThree);
                    //  Response.Write("tc  " + tckimlikNoYeni + "</br>");
                }

                // üretilen tc i diziye atama
                char[] birlestir = new char[11];
                birlestir = tckimlikNoYeni.ToCharArray();
                string sDonustur;
                int ata = 0;
                int topla = 0;

                for (int i = 0; i < birlestir.Length; i++)
                {

                    sDonustur = Convert.ToString(birlestir[i]);
                    ata = Int32.Parse(sDonustur);

                    topla = topla + ata;
                }

                // Response.Write(topla + "</br>");
                string sConvert = Convert.ToString(topla);
                char[] cConvert = new char[1];
                cConvert = sConvert.ToCharArray();
                string xxx = Convert.ToString(sConvert[1]);
                int deger = Int32.Parse(xxx);
                /// Response.Write(deger + "</br>");
                int StepFour = 0;

                while (deger != 8)
                {
                    deger++;
                    StepFour++;

                }

                ///Response.Write(deger + "</br>");
                /// Response.Write(sayac + "</br>");

                String Tc = Convert.ToString(StepOne) + Convert.ToString(StepTwo) + Convert.ToString(StepFour) + Convert.ToString(StepThree);
                // Response.Write(" yeni tc " + Tc + "</br>");





                // Kimliği doğrulama 
                long tckimlik = long.Parse(Tc);
                int dogumyili = int.Parse(txtDogumYili.Text);

                bool? durum;

                //Response.Write(tckimlik + "</br>");


                try
                {
                    using (KimlikDogrulamasi.KPSPublicSoapClient servis = new KimlikDogrulamasi.KPSPublicSoapClient())
                    {
                        durum = servis.TCKimlikNoDogrula(tckimlik, txtAd.Text.ToUpper(), txtSoyad.Text.ToUpper(), dogumyili);
                    }
                }
                catch
                {
                    Label7.Text = "";
                    durum = null;
                    Label5.Text = ("Hata var.");
                    Label5.ForeColor = System.Drawing.Color.Red;
                    txtTcKimlikNo.Focus();
                }
                if (durum == true)
                {
                    Label5.Text = "";
                    Label7.Text = (txtAd.Text + " " + txtSoyad.Text + "T.C. Kimlik Doğrudur");
                    Label7.ForeColor = System.Drawing.Color.Green;
                    txtTcKimlikNo.Focus();
                }
                else
                {

                    Label5.Text = ("Böyle bir T.C. Kimlik No Bulunmamaktadır");
                    Label5.ForeColor = System.Drawing.Color.Red;
                    Label7.Text = "";
                    txtTcKimlikNo.Focus();
                }
            }
        }

       
    }
}