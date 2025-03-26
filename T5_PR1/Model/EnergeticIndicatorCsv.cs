using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Model
{
    public class EnergeticIndicatorCsv
    {
        [Name("Data")]
        [Required(ErrorMessage = "La Data  és obligatori.")]
        public DateTime? Data { get; set; }

        [Name("PBEE_Hidroelectr")]
        public double PBEE_Hidroelectr { get; set; }

        [Name("PBEE_Carbo")]
        public double PBEE_Carbo { get; set; }

        [Name("PBEE_GasNat")]
        public double PBEE_GasNat { get; set; }

        [Name("PBEE_Fuel-Oil")]
        public double PBEE_Fuel_Oil { get; set; }

        [Name("PBEE_CiclComb")]
        public double PBEE_CiclComb { get; set; }

        [Name("PBEE_Nuclear")]
        public double PBEE_Nuclear { get; set; }

        [Name("CDEEBC_ProdBruta")]
        public double CDEEBC_ProdBruta { get; set; }

        [Name("CDEEBC_ConsumAux")]
        public double CDEEBC_ConsumAux { get; set; }

        [Name("CDEEBC_ProdNeta")]
        [Required(ErrorMessage = "El CDEEBC_ProdNeta  és obligatori.")]
        public double CDEEBC_ProdNeta { get; set; }

        [Name("CDEEBC_ConsumBomb")]
        public double CDEEBC_ConsumBomb { get; set; }

        [Name("CDEEBC_ProdDisp")]
        [Required(ErrorMessage = "El CDEEBC_ProdDisp  és obligatori.")]
        public double CDEEBC_ProdDisp { get; set; }

        [Name("CDEEBC_TotVendesXarxaCentral")]
        public double CDEEBC_TotVendesXarxaCentral { get; set; }

        [Name("CDEEBC_SaldoIntercanviElectr")]
        public double CDEEBC_SaldoIntercanviElectr { get; set; }

        [Name("CDEEBC_DemandaElectr")]
        [Required(ErrorMessage = "El CDEEBC_DemandaElectr  és obligatori.")]
        public double CDEEBC_DemandaElectr { get; set; }


        [Name("CDEEBC_TotalEBCMercatRegulat")]
        public string? CDEEBC_TotalEBCMercatRegulat { get; set; }

        [Name("CDEEBC_TotalEBCMercatLliure")]
        public string? CDEEBC_TotalEBCMercatLliure { get; set; }

     
        [Name("FEE_Industria")]
        public double? FEE_Industria { get; set; }

    
        [Name("FEE_Terciari")]
        public double? FEE_Terciari { get; set; }

   
        [Name("FEE_Domestic")]
        public double? FEE_Domestic { get; set; }

     
        [Name("FEE_Primari")]
        public double? FEE_Primari { get; set; }

      
        [Name("FEE_Energetic")]
        public double? FEE_Energetic { get; set; }

  
        [Name("FEEI_ConsObrPub")]
        public double? FEEI_ConsObrPub { get; set; }

     
        [Name("FEEI_SiderFoneria")]
        public double? FEEI_SiderFoneria { get; set; }

     
        [Name("FEEI_Metalurgia")]
        public double? FEEI_Metalurgia { get; set; }

   
        [Name("FEEI_IndusVidre")]
        public double? FEEI_IndusVidre { get; set; }

    
        [Name("FEEI_CimentsCalGuix")]
        public double? FEEI_CimentsCalGuix { get; set; }

      
        [Name("FEEI_AltresMatConstr")]
        public double? FEEI_AltresMatConstr { get; set; }

       
        [Name("FEEI_QuimPetroquim")]
        public double? FEEI_QuimPetroquim { get; set; }

        
        [Name("FEEI_ConstrMedTrans")]
        public double? FEEI_ConstrMedTrans { get; set; }

        
        [Name("FEEI_RestaTransforMetal")]
        public double? FEEI_RestaTransforMetal { get; set; }

        
        [Name("FEEI_AlimBegudaTabac")]
        public double? FEEI_AlimBegudaTabac { get; set; }

        [Name("FEEI_TextilConfecCuirCalçat")]
        public double? FEEI_TextilConfecCuirCalçat { get; set; }

        
        [Name("FEEI_PastaPaperCartro")]
        public double? FEEI_PastaPaperCartro { get; set; }

       
        [Name("FEEI_AltresIndus")]
        public double? FEEI_AltresIndus { get; set; }

        [Name("DGGN_PuntFrontEnagas")]
        public double DGGN_PuntFrontEnagas { get; set; }

        [Name("DGGN_DistrAlimGNL")]
        public double DGGN_DistrAlimGNL { get; set; }

        [Name("DGGN_ConsumGNCentrTerm")]
        public double DGGN_ConsumGNCentrTerm { get; set; }

        [Name("CCAC_GasolinaAuto")]
        [Required(ErrorMessage = "El CCAC_GasolinaAuto  és obligatori.")]
        public double CCAC_GasolinaAuto { get; set; }

        [Name("CCAC_GasoilA")]
        public double CCAC_GasoilA { get; set; }

    }
}
