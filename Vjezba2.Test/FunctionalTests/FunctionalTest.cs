using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vjezba2.Test.FunctionalTests
{
    [TestFixture]
    public class FunctionalTest
    {
        [Test]
        public void FunctionalTest_Chrome()
        {
            // Making chrome headless
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");

            IWebDriver driver = new ChromeDriver(@"C:\Users\TruLLi\source\repos\ParadigmeProjekt\ChromeDrivers");

            // Initialize the Chrome Driver
            using (driver )
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                // Open page locally
                driver.Navigate().GoToUrl("https://www.immowelt.de/anbieten/mietvertrag-erstellen/generator");

                #region Adresse des Objekts (1)

                // Strasse
                TestManagerSetup.SendKeysById(wait, "RequestParameters_RentedPremiseStreet", RandomString(50));

                //Hausnummer
                TestManagerSetup.SendKeysById(wait, "RequestParameters_RentedPremiseHouseNo", RandomString(10));

                // PLZ
                TestManagerSetup.SendKeysById(wait, "RequestParameters_RentedPremisePostcode", "20095");

                // Clicking a city from a dropdown list
                TestManagerSetup.Click(wait, "//div[@id='RequestParameters_RentedPremisePostcodeAutocompleteContent']/ul/li");

                // Geschoss
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Floors", RandomNumber(-999, 1000));

                // Zusatz
                TestManagerSetup.SendKeysById(wait, "RequestParameters_AdditionalInformation", RandomString(100));

                // Besondere Lage
                TestManagerSetup.Click(wait, "//label[contains(.,'Vorderhaus')]");

                // Eigentümergemeinschaft
                TestManagerSetup.Click(wait, "//label[contains(.,'Immobilie ist Bestandteil einer Eigentümergemeinschaft')]");

                //Weiter button
                TestManagerSetup.Click(wait, "//button[contains(.,'Weiter')]");

                #endregion

                #region Mieträume (2)
                // Anzahl der Personen die zu Vertragsbeginn die Immobilie nutzen
                TestManagerSetup.SendKeysById(wait, "RequestParameters_NumberOfPersonsUsingRentedPremise", RandomNumber(1, 1000));

                // Zimmer
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Rooms", RandomNumber(0, 1000));

                // Küche
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Kitchens", RandomNumber(0, 1000));

                // Bad/Dusche/Toilette
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Bathrooms", RandomNumber(0, 1000));

                // Flur/Diele
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Hallways", RandomNumber(0, 1000));

                // Abstellraum
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Storerooms", RandomNumber(0, 1000));

                // Keller
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[7]/fieldset/div/label");

                // Keller Nr.
                //TestManagerSetup.SendKeysById(wait, "RequestParameters_CellarNo", RandomString(20));

                // Dachboden
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[8]/fieldset/div/label");

                // Garten
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[9]/fieldset/div/label");

                // Garage
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[10]/fieldset/div/label");

                // Tiefgarage
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[11]/fieldset/div/label");

                // Stellplatz
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div/div[12]/fieldset/div/label");

                // Wohnungsschlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_ApartmentKeys", RandomNumber(0, 1000));

                // Kellerschlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_CellarKeys", RandomNumber(0, 1000));

                // Dachbodenschlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_AtticKeys", RandomNumber(0, 1000));

                // Haustürschlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_FrontDoorKeys", RandomNumber(0, 1000));

                // Briefkastenschlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_MailboxKeys", RandomNumber(0, 1000));

                // Weitere Schlüssel
                TestManagerSetup.SendKeysById(wait, "RequestParameters_AdditionalKeys", RandomString(100));

                // Weiter button
                TestManagerSetup.Click(wait, "//div[@id='rentedPremises']/div[2]/button[2]");
                #endregion

                #region Vertragsdaten (3)

                // Beginn des Mietverhältnisses
                TestManagerSetup.Click(wait, "//span[contains(.,'Vertragsdaten')]");

                TestManagerSetup.SendKeysById(wait, "RequestParameters_StartDate", "01.01.2020");

                // Befristung des Vertrags
                //IWebElement befristung = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("RentExpirationType2")));
                //befristung.Click();

                // Ende der Mietzeit
                //IWebElement endDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("RequestParameters_EndDate")));
                //endDate.SendKeys("01.02.2022");

                // Grund für Befristung
                //IWebElement grund = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("RequestParameters_ExpirationReason")));
                //grund.SendKeys(RandomString(400));

                // Weiter
                TestManagerSetup.Click(wait, "//div[@id='contractData']/div[2]/button[2]");

                #endregion

                #region Miete und Betriebskosten (4)

                // Grundmiete (sog. "Kaltmiete") 
                TestManagerSetup.SendKeysById(wait, "RequestParameters_BasicAmount", RandomNumber(1, 100000));

                // ggf. Stellplatz
                TestManagerSetup.SendKeysById(wait, "RequestParameters_ParkingSpaceAmount", RandomNumber(1, 100000));

                // Betriebskosten * naming?
                TestManagerSetup.SendKeysById(wait, "RequestParameters.BetrKVAmount", RandomNumber(1, 100000));

                // Kaution
                TestManagerSetup.SendKeysById(wait, "RequestParameters_DepositAmount", RandomNumber(1, 3));

                // Weiter
                TestManagerSetup.Click(wait, "//div[@id='rentAndOperatingCosts']/div[2]/button[2]");

                #endregion

                #region Vertragspartner (5)

                // Eigentümer Vorname
                TestManagerSetup.Click(wait, "//li[contains(.,'Vertragspartner')]");

                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_FirstName", RandomString(40));

                // Nachname 
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_LastName", RandomString(40));

                // Straße
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_Street", RandomString(50));

                // Hausnr.
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_HouseNo", RandomNumber(1, 10000000));

                // PLZ
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_Postcode", "20095");

                // Ort
                TestManagerSetup.Click(wait, "//div[@id='RequestParameters_Landlord_PostcodeAutocompleteContent']/ul/li/label");

                // Kontoinhaber
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_AccountOwner", RandomString(100));

                // IBAN
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Landlord_IBAN", "DE 66 6429 1420 0004 4630 05");

                // Mieter 1 Vorname
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Tenants[0]_FirstName", RandomString(40));

                // Mieter 1 Nachname
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Tenants[0]_LastName", RandomString(40));

                // Mieter 1 Straße
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Tenants[0]_Street", RandomString(50));

                // Mieter 1 Hausnr. 
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Tenants[0]_HouseNo", RandomNumber(1, 10000000));

                // Mieter 1 PLZ
                TestManagerSetup.SendKeysById(wait, "Tenant0_Postcode", "20095");

                // Mieter 1 Ort
                TestManagerSetup.Click(wait, "//div[@id='Tenant0AutocompleteContent']/ul/li/label");

                // Mieter 1 E-Mail
                TestManagerSetup.SendKeysById(wait, "RequestParameters_Tenants[0]_Email", (RandomString(30) + "@" + RandomString(19)));

                // Vertrag generieren

                #endregion

                #region Editing and deleting contract


                #endregion
            }
        }
        #region Randomizers

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&/()=?*-+,.;0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max).ToString();
        }
        #endregion
    }
}
