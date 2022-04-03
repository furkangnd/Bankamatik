using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double bakiye = 500;
            string sifre = "abc12";

        BASA:
            Console.WriteLine("Kartlı işlem 1\nKartsız işlem 2");
            string secim = Console.ReadLine();
            if (secim == "1")
            {
                Console.WriteLine("******* KARTLI İŞLEMLER *******");
                bool Giris = false;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Şifreniz:");
                    string sfr = Console.ReadLine();

                    if (sfr == sifre)
                    {
                        Giris = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Şifre Hatası!!!");
                    }
                }




                if (Giris) // if(true)
                {
                ANAMENU:
                    Console.WriteLine(" ********** ANA MENÜ **********\nPara Çekmek için    1\nPara yatırmak için  2\nPara Transferleri   3\nEğitim Ödemeleri    4\nÖdemeler            5\nBilgi Güncelleme    6\nÇıkış               7\nSeçiniz: ");
                    int secimAna = Convert.ToInt32(Console.ReadLine());
                    #region Para Çekme
                    if (secimAna == 1)
                    {
                        Console.WriteLine("Çekilecek Miktar:");
                        double miktar = Convert.ToDouble(Console.ReadLine());

                        if (bakiye >= miktar)
                        {
                            bakiye -= miktar;
                            Console.WriteLine("Paranızı Alınız. Yeni Bakiyeniz:" + bakiye);
                            goto ANAMENU;
                        }
                        else
                        {
                        CEK:
                            Console.WriteLine("Yetersiz Bakiye!!!\nAna Menü 9\nÇıkmak için 0\nSeçiminiz:");
                            int result = Convert.ToInt32(Console.ReadLine());
                            if (result == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (result == 0)
                            {
                                Console.WriteLine("Çıkış Yapılıyor...");
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            else
                            {
                                goto CEK;
                            }

                        }

                    }
                    #endregion
                    #region Para Yatırma
                    else if (secimAna == 2)
                    {
                    YATIR:
                        Console.WriteLine("Kredi Kartı için 1\nKendi Hesabı için 2\nSeçiminiz:");
                        int secimYatir = Convert.ToInt32(Console.ReadLine());
                        if (secimYatir == 1)
                        {
                          

                            Console.WriteLine("Kredi kart no:");
                            string krediKartNo = Console.ReadLine();
                            if (krediKartNo.Length == 12)
                            {
                                Console.WriteLine("Yatırılacak Miktar:");
                                double miktar = Convert.ToDouble(Console.ReadLine());

                                if (bakiye >= miktar)
                                {
                                    bakiye -= miktar;
                                    Console.WriteLine("Kredi kartına yatırma işlemi başarılı.Yeni Bakiyeniz:" + bakiye);
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz Bakiye!!!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Kredi Kart No!!!");
                            }
                        }
                        else if (secimYatir == 2)
                        {
                            Console.WriteLine("Yatırılacak Miktar:");
                            int miktar = Convert.ToInt32(Console.ReadLine());

                            bakiye += miktar;
                            Console.WriteLine("Yeni Bakiyeniz:" + bakiye);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Seçim!!");
                            goto YATIR;
                        }
                    DONUS:
                        Console.WriteLine("Ana Menü 9\nÇıkmak için 0\nSeçiminiz:");
                        int result = Convert.ToInt32(Console.ReadLine());
                        if (result == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (result == 0)
                        {
                            Console.WriteLine("Çıkış Yapılıyor...");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto DONUS;
                        }

                    }
                    #endregion
                    #region Para Transfer
                    else if (secimAna == 3)
                    {
                    TRANSFER:
                        Console.WriteLine("Başka Hesaba EFT 1\nBaşka Hesaba Havale 2\nSeçiminiz:");
                        int secimTrans = Convert.ToInt32(Console.ReadLine());

                        if (secimTrans == 1)
                        {
                            Console.WriteLine("Hesap no:");
                            string hesapNo = Console.ReadLine();
                            if (hesapNo.Length == 12)
                            {
                                Console.WriteLine("Transfer Edilecek Miktar:");
                                double miktar = Convert.ToDouble(Console.ReadLine());

                                if (bakiye >= miktar)
                                {
                                    bakiye -= miktar;
                                    Console.WriteLine("Transfer işlemi başarılı.Yeni Bakiyeniz:" + bakiye);
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz Bakiye!!!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hatalı Hesap No!!!");
                            }
                        }
                        else if (secimTrans == 2)
                        {
                            Console.WriteLine("IBAN No:");
                            string iban = Console.ReadLine().ToUpper();

                            if (iban.StartsWith("TR")) // if(iban[0]=="T" && iban[1]=="R")
                            {
                                if (iban.Substring(2).Length == 12)
                                {
                                    Console.WriteLine("Transfer edilecek miktar:");
                                    double miktar = Convert.ToDouble(Console.ReadLine());
                                    if (bakiye >= miktar)
                                    {
                                        bakiye -= miktar;
                                        Console.WriteLine("Transfer işlemi başarılı.Yeni Bakiyeniz:" + bakiye);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Yetersiz Bakiye!!!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("TR den sonra 12 haneli bir rakam dizisi girilmeli.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Iban bilgisinin başında TR olmalıdır.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Seçim!!!");
                            goto TRANSFER;
                        }
                    DONUS:
                        Console.WriteLine("Ana Menü 9\nÇıkmak için 0\nSeçiminiz:");
                        int result = Convert.ToInt32(Console.ReadLine());
                        if (result == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (result == 0)
                        {
                            Console.WriteLine("Çıkış Yapılıyor...");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto DONUS;
                        }
                    }
                    #endregion
                    else if (secimAna == 4)
                    {
                        Console.WriteLine("Eğitim Ödemeleri Sayfası Arızalı");
                    DONUS:
                        Console.WriteLine("Ana Menü 9\nÇıkmak için 0\nSeçiminiz:");
                        int result = Convert.ToInt32(Console.ReadLine());
                        if (result == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (result == 0)
                        {
                            Console.WriteLine("Çıkış Yapılıyor...");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto DONUS;
                        }
                    }
                    else if (secimAna == 5)
                    {
                        Console.WriteLine("Elektrik Faturası 1\nTelefon Faturası2\nİnternet Faturası 3\nSu Faturası 4\nOGS Ödemesi 5\n Seçiminiz: ");
                        int secimFatura = Convert.ToInt32(Console.ReadLine());

                        if (secimFatura == 1)
                        {
                            if (bakiye >= 50)
                            {
                                bakiye -= 50;
                                Console.WriteLine("Ödeme Başarılı.Yeni Bakiye:" + bakiye);
                            }
                        }
                        else if (secimFatura == 2)
                        {
                            if (bakiye >= 50)
                            {
                                bakiye -= 50;
                                Console.WriteLine("Ödeme Başarılı.Yeni Bakiye:" + bakiye);
                            }
                        }
                        else if (secimFatura == 3)
                        {
                            if (bakiye >= 50)
                            {
                                bakiye -= 50;
                                Console.WriteLine("Ödeme Başarılı.Yeni Bakiye:" + bakiye);
                            }

                        }
                        else if (secimFatura == 4)
                        {
                            if (bakiye >= 50)
                            {
                                bakiye -= 50;
                                Console.WriteLine("Ödeme Başarılı.Yeni Bakiye:" + bakiye);
                            }
                        }
                        else if (secimFatura == 5)
                        {
                            if (bakiye >= 50)
                            {
                                bakiye -= 50;
                                Console.WriteLine("Ödeme Başarılı.Yeni Bakiye:" + bakiye);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı fatura Seçimi!!!");
                        }

                    DONUS:
                        Console.WriteLine("Ana Menü 9\nÇıkmak için 0\nSeçiminiz:");
                        int result = Convert.ToInt32(Console.ReadLine());
                        if (result == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (result == 0)
                        {
                            Console.WriteLine("Çıkış Yapılıyor...");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto DONUS;
                        }

                    }
                    else if (secimAna == 6)
                    {
                    SIFRE:
                        Console.WriteLine("Şifre Değiştirmek için 1\nAna Menü 9\nÇıkmak için 0\nSeçiminiz:");
                        int secimSfr = Convert.ToInt32(Console.ReadLine());

                        if (secimSfr == 1)
                        {
                            Console.WriteLine("Eski Şifreniz:");
                            string oldSfr = Console.ReadLine();
                            if (oldSfr == sifre)
                            {
                            SIFRETEKRAR:
                                Console.WriteLine("Yeni Şifre:");
                                string newSfr = Console.ReadLine();
                                Console.WriteLine("Tekrar Yeni Şifre:");
                                string newSfr2 = Console.ReadLine();

                                if (newSfr == newSfr2)
                                {
                                    sifre = newSfr;
                                    goto BASA;
                                }
                                else
                                {
                                    Console.WriteLine("Şifreler Uyuşmuyor.");
                                    goto SIFRETEKRAR;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Şifre Hatası!!!");
                                goto SIFRE;
                            }
                        }
                        else if (secimSfr == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (secimSfr == 0)
                        {
                            Console.WriteLine("Çıkış Yapılıyor...");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            goto SIFRE;
                        }

                    }
                    else if (secimAna == 7)
                    {
                        Console.WriteLine("Çıkış Yapılıyor...");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Ana Menü Seçimi!!!");
                        goto ANAMENU;
                    }

                }
                else
                {
                    
                    Console.WriteLine("Giriş Hakkınız Bitti!!!");
                    Thread.Sleep(5000); 
                    goto BASA;
                }

            }

            else if (secim == "2")
            {
                Console.WriteLine("******* KARTSIZ İŞLEMLER *******");
                bool Giris = false;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Şifreniz: ");
                    string sfr = Console.ReadLine();

                    if (sfr == sifre)
                    {
                        Giris = true;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Şifre Hatası!!!");
                        goto BASA;
                    }

                 }

                if (Giris)
                {
                KARTSIZ:
                    Console.WriteLine("Kredi Kartına Transfer Yapmak İçin  1\nKendi Kartını Para Yatırmak İçin 2\nAna Menüye Dönmek İçin 9\nÇıkmak İçin 0\nSeçiminiz: ");
                    int kartsızSecim = Convert.ToInt32(Console.ReadLine());
                    if (kartsızSecim == 1)
                    {
                    KARTNO:
                        Console.WriteLine("Kredi Kart Numarasını Giriniz: ");
                        string krediKartNo = (Console.ReadLine());
                        if (krediKartNo.Length == 12)
                        {
                        KARTSIZBAKİYE:
                            Console.WriteLine("Transfer Edilecek Miktarı Giriniz:");
                            double miktar = Convert.ToDouble(Console.ReadLine());

                            if (bakiye >= miktar)
                            {
                                bakiye -= miktar;
                                Console.WriteLine("Transfer İşlemi Başarı İle Gerçekleşti.Yeni bakiyeniz:" + bakiye);
                                

                            }
                            else
                            { 
                                Console.WriteLine("Geçersiz Bakiye Girdiniz\nÜcreti Tekrar Girmek İçin 1 \nAna Menüye Dönmek İçin 2\nÇıkış Yapmak İçin 0 ");
                                kartsızSecim = Convert.ToInt32(Console.ReadLine());
                                if (kartsızSecim==1)
                                {
                                    goto KARTSIZBAKİYE;
                                    
                                }
                                else if (kartsızSecim==2)
                                {
                                    goto KARTSIZ;
                                }
                                else
                                {

                                    Console.WriteLine("Çıkış Yapılıyor...");
                                    Thread.Sleep(2000);
                                    Environment.Exit(0);
                                }
                               
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Hesap Numarası Girdiniz.Tekrar Deneyiniz: ");
                            goto KARTNO;
                        }
                    }

                    if (kartsızSecim == 2)
                    {
                        Console.WriteLine("Hesabınıza Yatırılacak Miktarı Giriniz: ");
                        double ytrİslem = Convert.ToDouble(Console.ReadLine());

                        bakiye += ytrİslem;
                        Console.WriteLine("Yeni Bakiyeniz: " + bakiye);
                        Console.WriteLine("ANA Menüye Dönmek İçin 9 \nÇıkış Yapmak İçin 0 ");

                        
                    }

                    if (kartsızSecim==9)
                    {
                        goto BASA;
                    }
                    if (kartsızSecim==0)
                    {

                        Console.WriteLine("Çıkış Yapılıyor...");
                        Thread.Sleep(2000);
                        Environment.Exit(0);

                    }
                    
                }

            }
        } 
    }
}
/*

Console.WriteLine("Elektrik Faturası     1\n" +
             "Telefon Faturası        2\n" +
             "İnternet faturası       3\n" +
             "Su Faturası             4\n" +
             "OGS Ödemeleri           5\nSeçiminiz:");

Console.WriteLine("Elektrik Faturası 1\nTelefon Faturası2\nİnternet Faturası 3\nSu Faturası 4\OGS Ödemesi 5\n Seçiminiz: ");



*/
