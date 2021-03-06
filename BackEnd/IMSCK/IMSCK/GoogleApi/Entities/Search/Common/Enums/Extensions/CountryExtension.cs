namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// Country Extension methods.
    /// </summary>
    public static class CountryExtension
    {
        /// <summary>
        /// Returns the Country restriction.
        /// </summary>
        /// <param name="country">The <see cref="Country"/>.</param>
        /// <returns>The <see cref="string"/> representation of the <see cref="Country"/> as 'cr' request parameter.</returns>
        public static string ToCr(this Country country)
        {
            switch (country)
            {
                case Country.Afghanistan: return "countryAF";
                case Country.Albania: return "countryAL";
                case Country.Algeria: return "countryDZ";
                case Country.AmericanSamoa: return "countryAS";
                case Country.Andorra: return "countryAD";
                case Country.Angola: return "countryAO";
                case Country.Anguilla: return "countryAI";
                case Country.Antarctica: return "countryAQ";
                case Country.AntiguaAndBarbuda: return "countryAG";
                case Country.Argentina: return "countryAR";
                case Country.Armenia: return "countryAM";
                case Country.Aruba: return "countryAW";
                case Country.Australia: return "countryAU";
                case Country.Austria: return "countryAT";
                case Country.Azerbaijan: return "countryAZ";
                case Country.Bahamas: return "countryBS";
                case Country.Bahrain: return "countryBH";
                case Country.Bangladesh: return "countryBD";
                case Country.Barbados: return "countryBB";
                case Country.Belarus: return "countryBY";
                case Country.Belgium: return "countryBE";
                case Country.Belize: return "countryBZ";
                case Country.Benin: return "countryBJ";
                case Country.Bermuda: return "countryBM";
                case Country.Bhutan: return "countryBT";
                case Country.Bolivia: return "countryBO";
                case Country.BosniaAndHerzegovina: return "countryBA";
                case Country.Botswana: return "countryBW";
                case Country.BouvetIsland: return "countryBV";
                case Country.Brazil: return "countryBR";
                case Country.BritishIndianOceanTerritory: return "countryIO";
                case Country.BruneiDarussalam: return "countryBN";
                case Country.Bulgaria: return "countryBG";
                case Country.BurkinaFaso: return "countryBF";
                case Country.Burundi: return "countryBI";
                case Country.Cambodia: return "countryKH";
                case Country.Cameroon: return "countryCM";
                case Country.Canada: return "countryCA";
                case Country.CapeVerde: return "countryCV";
                case Country.CaymanIslands: return "countryKY";
                case Country.CentralAfricanRepublic: return "countryCF";
                case Country.Chad: return "countryTD";
                case Country.Chile: return "countryCL";
                case Country.China: return "countryCN";
                case Country.ChristmasIsland: return "countryCX";
                case Country.CocosIslands: return "countryCC";
                case Country.Colombia: return "countryCO";
                case Country.Comoros: return "countryKM";
                case Country.Congo: return "countryCG";
                case Country.TheDemocraticRepublicOfCongo: return "countryCD";
                case Country.CookIslands: return "countryCK";
                case Country.CostaRica: return "countryCR";
                case Country.CoteDivoire: return "countryCI";
                case Country.Croatia: return "countryHR";
                case Country.Cuba: return "countryCU";
                case Country.Cyprus: return "countryCY";
                case Country.CzechRepublic: return "countryCZ";
                case Country.Denmark: return "countryDK";
                case Country.Djibouti: return "countryDJ";
                case Country.Dominica: return "countryDM";
                case Country.DominicanRepublic: return "countryDO";
                case Country.EastTimor: return "countryTP";
                case Country.Ecuador: return "countryEC";
                case Country.Egypt: return "countryEG";
                case Country.ElSalvador: return "countrySV";
                case Country.EquatorialGuinea: return "countryGQ";
                case Country.Eritrea: return "countryER";
                case Country.Estonia: return "countryEE";
                case Country.Ethiopia: return "countryET";
                case Country.EuropeanUnion: return "countryEU";
                case Country.FalklandIslAndsMalvinas: return "countryFK";
                case Country.FaroeIslands: return "countryFO";
                case Country.Fiji: return "countryFJ";
                case Country.Finland: return "countryFI";
                case Country.France: return "countryFR";
                case Country.FranceMetropolitan: return "countryFX";
                case Country.FrenchGuiana: return "countryGF";
                case Country.FrenchPolynesia: return "countryPF";
                case Country.FrenchSouthernTerritories: return "countryTF";
                case Country.Gabon: return "countryGA";
                case Country.Gambia: return "countryGM";
                case Country.Georgia: return "countryGE";
                case Country.Germany: return "countryDE";
                case Country.Ghana: return "countryGH";
                case Country.Gibraltar: return "countryGI";
                case Country.Greece: return "countryGR";
                case Country.Greenland: return "countryGL";
                case Country.Grenada: return "countryGD";
                case Country.Guadeloupe: return "countryGP";
                case Country.Guam: return "countryGU";
                case Country.Guatemala: return "countryGT";
                case Country.Guinea: return "countryGN";
                case Country.GuineaBissau: return "countryGW";
                case Country.Guyana: return "countryGY";
                case Country.Haiti: return "countryHT";
                case Country.HeardIslandAndMcdonaldIslands: return "countryHM";
                case Country.VaticanCityState: return "countryVA";
                case Country.Honduras: return "countryHN";
                case Country.HongKong: return "countryHK";
                case Country.Hungary: return "countryHU";
                case Country.Iceland: return "countryIS";
                case Country.India: return "countryIN";
                case Country.Indonesia: return "countryID";
                case Country.Iran: return "countryIR";
                case Country.Iraq: return "countryIQ";
                case Country.Ireland: return "countryIE";
                case Country.Israel: return "countryIL";
                case Country.Italy: return "countryIT";
                case Country.Jamaica: return "countryJM";
                case Country.Japan: return "countryJP";
                case Country.Jordan: return "countryJO";
                case Country.Kazakhstan: return "countryKZ";
                case Country.Kenya: return "countryKE";
                case Country.Kiribati: return "countryKI";
                case Country.DemocraticPeoplesRepublicOfKorea: return "countryKP";
                case Country.RepublicOfKorea: return "countryKR";
                case Country.Kuwait: return "countryKW";
                case Country.Kyrgyzstan: return "countryKG";
                case Country.LaoPeoplesDemocraticRepublic: return "countryLA";
                case Country.Latvia: return "countryLV";
                case Country.Lebanon: return "countryLB";
                case Country.Lesotho: return "countryLS";
                case Country.Liberia: return "countryLR";
                case Country.LibyanArabJamahiriya: return "countryLY";
                case Country.Liechtenstein: return "countryLI";
                case Country.Lithuania: return "countryLT";
                case Country.Luxembourg: return "countryLU";
                case Country.Macao: return "countryMO";
                case Country.Macedonia: return "countryMK";
                case Country.Madagascar: return "countryMG";
                case Country.Malawi: return "countryMW";
                case Country.Malaysia: return "countryMY";
                case Country.Maldives: return "countryMV";
                case Country.Mali: return "countryML";
                case Country.Malta: return "countryMT";
                case Country.MarshallIslands: return "countryMH";
                case Country.Martinique: return "countryMQ";
                case Country.Mauritania: return "countryMR";
                case Country.Mauritius: return "countryMU";
                case Country.Mayotte: return "countryYT";
                case Country.Mexico: return "countryMX";
                case Country.Micronesia: return "countryFM";
                case Country.Moldova: return "countryMD";
                case Country.Monaco: return "countryMC";
                case Country.Mongolia: return "countryMN";
                case Country.Montserrat: return "countryMS";
                case Country.Morocco: return "countryMA";
                case Country.Mozambique: return "countryMZ";
                case Country.Myanmar: return "countryMM";
                case Country.Namibia: return "countryNA";
                case Country.Nauru: return "countryNR";
                case Country.Nepal: return "countryNP";
                case Country.Netherlands: return "countryNL";
                case Country.NetherlandsAntilles: return "countryAN";
                case Country.NewCaledonia: return "countryNC";
                case Country.NewZealand: return "countryNZ";
                case Country.Nicaragua: return "countryNI";
                case Country.Niger: return "countryNE";
                case Country.Nigeria: return "countryNG";
                case Country.Niue: return "countryNU";
                case Country.NorfolkIsland: return "countryNF";
                case Country.NorthernMarianaIslands: return "countryMP";
                case Country.Norway: return "countryNO";
                case Country.Oman: return "countryOM";
                case Country.Pakistan: return "countryPK";
                case Country.Palau: return "countryPW";
                case Country.PalestinianTerritory: return "countryPS";
                case Country.Panama: return "countryPA";
                case Country.PapuaNewGuinea: return "countryPG";
                case Country.Paraguay: return "countryPY";
                case Country.Peru: return "countryPE";
                case Country.Philippines: return "countryPH";
                case Country.Pitcairn: return "countryPN";
                case Country.Poland: return "countryPL";
                case Country.Portugal: return "countryPT";
                case Country.PuertoRico: return "countryPR";
                case Country.Qatar: return "countryQA";
                case Country.Reunion: return "countryRE";
                case Country.Romania: return "countryRO";
                case Country.RussianFederation: return "countryRU";
                case Country.Rwanda: return "countryRW";
                case Country.SaintHelena: return "countrySH";
                case Country.SaintKittsAndNevis: return "countryKN";
                case Country.SaintLucia: return "countryLC";
                case Country.SaintPierreAndMiquelon: return "countryPM";
                case Country.SaintVincentAndtheGrenadines: return "countryVC";
                case Country.Samoa: return "countryWS";
                case Country.SanMarino: return "countrySM";
                case Country.SaoTomeAndPrincipe: return "countryST";
                case Country.SaudiArabia: return "countrySA";
                case Country.Senegal: return "countrySN";
                case Country.SerbiaAndMontenegro: return "countryCS";
                case Country.Seychelles: return "countrySC";
                case Country.SierraLeone: return "countrySL";
                case Country.Singapore: return "countrySG";
                case Country.Slovakia: return "countrySK";
                case Country.Slovenia: return "countrySI";
                case Country.SolomonIslands: return "countrySB";
                case Country.Somalia: return "countrySO";
                case Country.SouthAfrica: return "countryZA";
                case Country.SouthGeorgiaAndTheSouthSAndwichIslands: return "countryGS";
                case Country.Spain: return "countryES";
                case Country.SriLanka: return "countryLK";
                case Country.Sudan: return "countrySD";
                case Country.Suriname: return "countrySR";
                case Country.SvalbardAndJanMayen: return "countrySJ";
                case Country.Swaziland: return "countrySZ";
                case Country.Sweden: return "countrySE";
                case Country.Switzerland: return "countryCH";
                case Country.SyrianArabRepublic: return "countrySY";
                case Country.Taiwan: return "countryTW";
                case Country.Tajikistan: return "countryTJ";
                case Country.Tanzania: return "countryTZ";
                case Country.Thailand: return "countryTH";
                case Country.Togo: return "countryTG";
                case Country.Tokelau: return "countryTK";
                case Country.Tonga: return "countryTO";
                case Country.TrinidadAndTobago: return "countryTT";
                case Country.Tunisia: return "countryTN";
                case Country.Turkey: return "countryTR";
                case Country.Turkmenistan: return "countryTM";
                case Country.TurksAndCaicosIslands: return "countryTC";
                case Country.Tuvalu: return "countryTV";
                case Country.Uganda: return "countryUG";
                case Country.Ukraine: return "countryUA";
                case Country.UnitedArabEmirates: return "countryAE";
                case Country.UnitedKingdom: return "countryUK";
                case Country.UnitedStates: return "countryUS";
                case Country.UnitedStatesMinorOutlyingIslands: return "countryUM";
                case Country.Uruguay: return "countryUY";
                case Country.Uzbekistan: return "countryUZ";
                case Country.Vanuatu: return "countryVU";
                case Country.Venezuela: return "countryVE";
                case Country.Vietnam: return "countryVN";
                case Country.VirginIslandsBritish: return "countryVG";
                case Country.VirginIslandsUs: return "countryVI";
                case Country.WallisandFutuna: return "countryWF";
                case Country.WesternSahara: return "countryEH";
                case Country.Yemen: return "countryYE";
                case Country.Yugoslavia: return "countryYU";
                case Country.Zambia: return "countryZM";
                case Country.Zimbabwe: return "countryZW";

                default:
                    return string.Empty;
            }
        }
    }
}