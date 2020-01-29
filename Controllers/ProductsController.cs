using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Fox.Microservices.Products.Models;
using Fox.Microservices.Products.Models.Entities;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPITools.Helpers;
using WebAPITools.ErrorHandling;
using WebAPITools.Models.Configuration;

namespace Fox.Microservices.Products.Controllers
{
    public enum Families
    {
        [Description("ampli-mini")]
        AmpliMini,
        [Description("ampli-easy")]
        AmpliEasy,
        [Description("ampli-energy")]
        AmpliEnergy,
        [Description("ampli-connect")]
        AmpliConnect
    }

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IOptions<AppSettings> Settings;
        private readonly ProductsContext DBContext;

        public ProductsController(IOptions<AppSettings> ASettings, ProductsContext ADBContext)
        {
            Settings = ASettings;
            DBContext = ADBContext;
        }

        // GET api/values
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ActionResult<IEnumerable<string>> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ProductListItem> Get(string id)
        {
            PD_S_PRODUCT Item = DBContext.PD_S_PRODUCT.FirstOrDefault(E => E.PRODUCT_CODE == id);

            if (Item == null)
                throw new NotFoundException(string.Format("No product found with key: '{0}'", id));

            ProductListItem Result = new ProductListItem(Item);
            Result.LoadExtData(DBContext, Item);
            return Result;
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="ProductCodes">
        /// ## ProductCodes single or separated by "|" ##
        /// <param name="Description">Fuzzy search in product description</param>
        /// <param name="Family">
        /// ## Family accepted values ##
        /// AmpliMini,
        /// AmpliEasy,
        /// AmpliEnergy,
        /// AmpliConnect
        /// </param>
        /// <param name="Style">
        /// ## Style accepeted values ##
        /// 000    Sub Class Not Defined
        /// 011    Consumables
        /// 040    Specialties
        /// 047    Battery 10
        /// 048    Battery 13
        /// 049    Battery 312
        /// 050    Battery 675
        /// 058    HA Cleaning
        /// 059    BTE
        /// 060    Receivers
        /// 073    HAs Remote Controls and Other
        /// 085    Other products Miscellaneous
        /// 096    Other batteries
        /// 0B0    Cleaning Sets Disc. - NL Only
        /// 0B5    HA Discounts - NL and USA Only
        /// 0C0 Other Products - Non Stock
        /// 0C8 HA Repairs
        /// 0D0    Earmolds
        /// 0F9    MOULDS
        /// 0G1 HA - Half Shell
        /// 0G2 HA - Canal
        /// 019    ITE, ITC, CIC
        /// 0G3 HA - Mini Canal
        /// 0G4 HA - CIC
        /// 0G5 HA - Cross - Bicross
        /// 0G6 HA - BTE - Open Fit
        /// 0G7 HA - BTE - RITC
        /// 0G8 HA - BTE - Standard
        /// 0J9 Alternative Listening Device
        /// 0N0 HA ITE OPEN
        /// 0N1 HA ITE RIC
        /// 0U4    HA-ITE-IFITC
        /// 0V0 Government Subsidy HA
        /// 0V1 Workcover Devices Fees
        /// 0V2 GE Payment HA
        /// 0V3 HA Refund
        /// 0V4 Top Up
        /// 0V5 Replacement Fee
        /// 0V6 OHS HA Fees
        /// 0V7 Assessment Fees
        /// 0V8 Special Assessment
        /// 0V9 OHS Assessment Fees
        /// 0W0 OHS Aid Adjust.Monaural
        /// 0W1 OHS Aid Adjust. Binaural
        /// 0W2 OHS Maintenance
        /// 0W3 Continuous Care
        /// 0W4 Workcover Maintenance
        /// 0W5 Battery Plan
        /// 0W6 Loss and Damage Plan
        /// 0W8 Out of Warr. Rep. - OHS
        /// 0W9 Out of Warr. Rep. - Private
        /// 0X0    HA Yearly Maintenance
        /// 0X1    HA Yearly Maintenance - Top Up
        /// 0X2    PO Clearing
        /// 0X3    Ampliclear
        /// 0X4    Freight
        /// 0Z0 HA - ITC
        /// 0Z1 HA - Bi/Cross
        /// 0Z2 HA - BTE RIC
        /// 0Z3 HA - BTE
        /// 0Z4 HA - ITE
        /// 0Z7 HA - IIC
        /// 0Z8 HA - BTE SP
        /// 0Z9 OHS EXCESS
        /// 0ZA CCP EXCESS
        /// 0ZB ABR Assessments
        /// 0ZC Impredance Assessments
        /// 0ZD OAE Assessments
        /// 0ZE ENT Diagnostic Assessments
        /// 0ZF Paediatric Assessments
        /// 0ZG Receivers
        /// 0ZH Domes
        /// 0ZI Tubes
        /// 0ZL Programming
        /// 0ZM Wax Guards
        /// 0ZN Other
        /// </param>
        /// <param name="Level">
        /// ## Level accepted values ##
        /// 1394    Bronze - Tier 1
        /// 1395    Diamond
        /// 1396    Economy
        /// 1397    Gold
        /// 1398    Silver
        /// 1408    Bronze - Tier 2
        /// </param>
        /// <param name="IsActive"></param>
        /// <param name="ClassCode">
        /// ## ClassCode accepted values ##
        /// 004 Hearing Aids Accessories
        /// 005 Batteries
        /// 008 Molds
        /// 009 Hearing Aids
        /// 012 Hearing Aid Spare Parts
        /// 013 Services
        /// 014 Consumables
        /// 015 Other Products        
        /// </param>
        /// <param name="SupplierCode">
        /// ## SupplierCode accepted values - single or separated by "|" ##
        /// 000 
        /// 001 AM
        /// 002 AMPLICORD
        /// 003 BRUCKHOFF
        /// 004 C.R.A.I.
        /// 005 COCHLEAR
        /// 006 COSELGI
        /// 007 D.A.SRL
        /// 008 D.P.I.SRL
        /// 009 DANAVOX
        /// 010 DEGIORGI
        /// 011 DREVE
        /// 012 ELEKTRO
        /// 013 EUROSONIT
        /// 014 EXHIBO
        /// 015 FRISCH
        /// 016 FRISCH-LABORSYSTEMS
        /// 017 HANSATONAKUSTIK
        /// 018 INTERACOUSTICS
        /// 019 INTERMEC
        /// 020 KNOWLES
        /// 021 LOCTITE
        /// 022 MICROTRONIC
        /// 023 MINICRAFT
        /// 024 NUOVACETI
        /// 025 OKINTERNATIONAL
        /// 026 OSADAELECTRIC
        /// 027 PHONAK
        /// 028 GNRESOUND
        /// 029 SIEMENS
        /// 030 STARKEY
        /// 031 VIRAB
        /// 032 WIDEX
        /// 033 VIENNATONE
        /// 034 OTICON
        /// 035 BERNAFON
        /// 036 SONICINN.
        /// 037 HANSATON
        /// 038 UNITRON
        /// 039 PHILIPS
        /// 040 REXTON
        /// 041 NOBELBIOCAREENTIFIC
        /// 042 DEAF
        /// 043 BETERHOREN
        /// 044 EURION
        /// 045 MICROTECH
        /// 046 MODUVICE
        /// 047 LABELLE
        /// 048 AUDIOSERVICE
        /// 049 EARSYPLUS
        /// 050 OMNIACOM
        /// 051 MIRACLEEAR
        /// 052 SONUS
        /// 053 INTERTON
        /// 054 SONAR
        /// 055 RION
        /// 056 AMPLIFON
        /// 057 OMIKRON
        /// 058 ANSAVOX
        /// 059 AUDIFON
        /// 060 AUDIOLAB
        /// 061 AUDINA
        /// 062 GREINER
        /// 063 IFH
        /// 064 INTRASON
        /// 065 KULMAN
        /// 066 PURETONE
        /// 067 NEWSON
        /// 068 AUTEL
        /// 069 MICROSON
        /// 070 ISOSONIC
        /// 071 OMNIA
        /// 072 TIBERVOX
        /// 073 PRODITON
        /// 074 AUDIOMEDI
        /// 075 BL
        /// 076 GAES
        /// 077 MITEL
        /// 078 MARCON
        /// 079 NOBELPHARMA
        /// 080 RAY-O-VAC
        /// 081 VARTA
        /// 082 ACTIVAIR
        /// 083 MALLORY
        /// 084 RENATA
        /// 085 TELEX
        /// 086 ELECTONE
        /// 087 UNISON
        /// 088 GYRUSINTERNATIONALLTD
        /// 089 CASIO
        /// 090 PROTAC
        /// 091 BIOTONE
        /// 092 AUDITECH
        /// 093 COMFOOR
        /// 094 BATTERYBENELUX
        /// 095 MGDEVELOPMENT
        /// 096 Varibel
        /// 097 POWERONE
        /// 098 SEBOTEK
        /// 099 FYSIC
        /// 100 CYBERPAC
        /// 217 rrr
        /// 387 BELTONE
        /// 432 ISOSONIC
        /// 500 DETAX
        /// 501 LISA
        /// 502 ELCEA
        /// 503 CLARION
        /// 504 SENNHEISER
        /// 505 HEINE
        /// 506 BATTERIJIMPORT
        /// 507 GEWA
        /// 508 BOSH
        /// 509 PHONICEAR
        /// 510 RADIOLIGHT
        /// 511 INFRALIGHT
        /// 512 MCS
        /// 513 MEDZORG
        /// 514 SONY
        /// 515 AUDIFRESH
        /// 516 HUMANTECHNICK
        /// 518 WESTRA
        /// 519 OTODYNAMICS
        /// 520 NATUS
        /// 521 IAC
        /// 522 HIMSA
        /// 523 GSI
        /// 524 FRYEELECTRONICS
        /// 525 FISCHERZOTH
        /// 526 DANPLEX
        /// 527 UNIVOX
        /// 528 CEDIS
        /// 530 METRONIC
        /// 531 EGGER
        /// 532 SOUNDID
        /// 533 TIPTEL
        /// 536 VIVATONE
        /// 537 WESTONE
        /// 538 PRAIRIELABS
        /// 539 EXSILENT
        /// 540 HEARINGAIDTECHNOLOGY(HAT)
        /// 541 MAGNATONE
        /// 542 KALMANNAUDIO
        /// 543 GOAMERICA
        /// 544 SMS
        /// 545 EUREKA
        /// 546 GEEMARC
        /// 547 MAGIC
        /// 548 BERMON
        /// 549 AUDI-LAB
        /// 550 GRAPHICECLAIR
        /// 551 MGDEVELOPPEMENT
        /// 552 ADVANCEDCOMMUNICATION
        /// 553 EARSONICSSAS
        /// 554 BIOACOUSTICS
        /// 555 2DO
        /// 556 ACOUSTICON
        /// 557 ADARZTBEDARF
        /// 558 ADVANCEDBIONICS
        /// 559 ALPINE
        /// 560 AMPLICOM
        /// 561 AMPLITON
        /// 562 ASCIONE
        /// 563 ASCOM
        /// 564 AUDIA
        /// 565 AUDIOLINE
        /// 566 AXCOM
        /// 567 AXT
        /// 568 BACHMAIER
        /// 569 BELLMAN
        /// 570 BHM
        /// 571 BILSOM
        /// 572 BR?MELHAUPT
        /// 573 CECEM
        /// 574 CONRAD
        /// 575 DISKOWSKI
        /// 576 DR.KUHN
        /// 577 DURACELL
        /// 578 EARBAGGMBH
        /// 579 EMMERICH
        /// 580 HEARSAFE
        /// 581 HEBA
        /// 582 HERWECKGMBH
        /// 583 HGT
        /// 584 HMS
        /// 585 H?AS
        /// 586 H?MANN
        /// 587 HUMANTECHNIK
        /// 588 INEAR
        /// 589 KIND
        /// 590 KIRCHNERUWILHELM
        /// 591 KLUXEN/HAMA
        /// 592 LABORATOIRESDIEPHARMEX
        /// 593 LEBIODA
        /// 594 LINKEH?SYSTEME
        /// 595 LITHIUM
        /// 596 LITRATON
        /// 597 LOGIA
        /// 598 MED-EL
        /// 599 MOCK
        /// 600 NICHTMEHRVERWENDEN
        /// 601 OPTIKERBODE
        /// 602 OTOMAG
        /// 603 PASCHEN
        /// 604 RUFUS
        /// 605 SCHWERH?IGENBUND
        /// 606 SERVOX
        /// 607 TELEFONMANN
        /// 608 VIELSTEDTER
        /// 609 VITAPHON
        /// 610 VODAFONE
        /// 611 AURIC
        /// 612 AUDINET
        /// 613 ENTIFIC
        /// 614 IBA
        /// 615 LISOUND
        /// 616 MEDIFON
        /// 617 NEWSOUND
        /// 618 RIONET
        /// 619 SANOMED
        /// 620 VICTON
        /// 621 AUDIOFON
        /// 622 AXA
        /// 623 VIBRANTMEDELHT
        /// 624 AMPLICLEAR
        /// 625 NEUROTONE
        /// 626 CLARITY
        /// 627 BELTEC
        /// 628 GHE
        /// 629 TELGO
        /// 630 COMFORTAUDIO
        /// 631 INSOUNDMEDICALINC.
        /// 632 SONA
        /// 633 H?LUCHS
        /// 634 SOLUTIONGROUP
        /// 635 AMPLICOMMS
        /// 636 BEGHELLI
        /// 637 LAICA SPA
        /// 639 INGRAM MICRO
        /// 643 Sennehiser
        /// 644 BHM-TECH
        /// 645 ORICOM
        /// 646 Word of Mouth
        /// VCAUDIOP Audio Prosthetics Pty Ltd                                   
        /// VCBELLPR Bellmark Printing                                           
        /// VCBERNAF Bernafon Australia Pty Ltd                                  
        /// VCBOISE Boise                                                       
        /// VCBRANBU Brandbuild                                                  
        /// VCCATR Catridges                                                   
        /// VCCOS COMPLETE OFFICE SUPPLIES                                    
        /// VCDHTEC DH Technology                                               
        /// VCEBOS EBOS                                                        
        /// VCEVERTO Evertone                                                    
        /// VCFIRST FIRST AID REPLENISHMENTS                                    
        /// VCHARSTO Harston and Partners                                        
        /// VCHIC Department of Health - Office of Hearing Services
        /// VCIDEA Idea to Action                                              
        /// VCIMPBER Impression boxes                                            
        /// VCINSTRU Instruman                                                   
        /// VCJUST JUST TOOLS                                                  
        /// VCLRINST LR INSTRUMENTS                                              
        /// VCMEDICA Medicare Australia
        /// VCMGDEVE MG Developments                                             
        /// VCNATIOH National Hearing Care                                    
        /// VCNEUROM Neuromonics                                                 
        /// VCOFFICP Office Print                                                
        /// VCOFFMAX OFFICEMAX                                                   
        /// VCOHS Office of Hearing Services                                  
        /// VCORICOM Oricom International Pty Ltd                                
        /// VCOTICON Oticon Australia Pty Ltd                                    
        /// VCP.FORM Photocopy Forms                                             
        /// VCPATEAC Paterson Acoustics                                          
        /// VCPHOENX Phoenix Instruments                                         
        /// VCPHONAK Phonak Australasia Pty Ltd                                  
        /// VCPIERHE Pierce Hearing                                              
        /// VCRAYOV RAYOVAC                                                     
        /// VCREIDTE Reid Technology Australia Pty Ltd                           
        /// VCRESOAU Resound Australia                                           
        /// VCRESOUA GN RESOUND                                                  
        /// VCSIEMHI Siemens Hearing Instruments Pty Ltd                         
        /// VCSONICI Miracle Ear/Sonic Innovations                               
        /// VCSTARKY Starkey Laboratories Pty Ltd                                
        /// VCSTELMA Stelmara Medical Supplies                                   
        /// VCSYNTEC Sennheiser Australia Pty Limited                            
        /// VCTOLLG Toll Priority                                               
        /// VCULTRA Ultra Supplies                                              
        /// VCUNITRO Unitron                                                     
        /// VCWIA048 VCWIA048
        /// VCWIDEX Widex Australia Pty Ltd                                     
        /// VCWORDOF Word of Mouth                                               
        /// VNAUDIOP Audio Prosthetics Pty Ltd                                   
        /// VNBERNAF Bernafon Australia Pty Ltd                                  
        /// VNBRANBU Brandbuild                                                  
        /// VNEBOSPL EBOS Group Pty Ltd
        /// VNEVERTO Evertone                                                    
        /// VNJUSTTO Just Tools
        /// VNLRINST LR Instruments                                              
        /// VNMGDEVE MG Developments                                             
        /// VNNATIOH National Hearing Care                                    
        /// VNNEUROM Neuromonics                                                 
        /// VNNHCGRP NHC Group
        /// VNOHS    Office of Hearing Services                                  
        /// VNORICOM Oricom International Pty Ltd                                
        /// VNOTICON Oticon Australia Pty Ltd                                    
        /// VNPATEAC Paterson Acoustics                                          
        /// VNPHOENX Phoenix Instruments                                         
        /// VNPHONAK Phonak Australasia Pty Ltd                                  
        /// VNPIERHE Pierce Hearing                                              
        /// VNREIDTE Reid Technology Australia Pty Ltd                           
        /// VNRESOAU Resound Australia                                           
        /// VNSENNHE Sennheiser                                                  
        /// VNSIEMHI Siemens Hearing Instruments Pty Ltd                         
        /// VNSONICI Miracle Ear/Sonic Innovations                               
        /// VNSPECTR SPECTRUM BATTERIES INC.
        /// VNSTARKY Starkey Laboratories Pty Ltd                                
        /// VNSYNTEC Sennheiser Australia Pty Limited                            
        /// VNULTRA Ultra Suppliers Pty Ltd
        /// VNUNITRO Unitron                                                     
        /// VNWIDEX  Widex Australia Pty Ltd                                     
        /// VNWORDOF Word of Mouth                                               
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ProductListItem>> Search(string ProductCodes, string Description, Families? Family, string Style, int? Level, string SupplierCode, string ClassCode, bool? IsActive = true)
        {
            if (string.IsNullOrWhiteSpace(ProductCodes) && string.IsNullOrWhiteSpace(Description) && !Family.HasValue && string.IsNullOrWhiteSpace(Style) && string.IsNullOrWhiteSpace(SupplierCode) && string.IsNullOrWhiteSpace(ClassCode))
                throw new Exception("At least one parameter is needed to call this api");

            var qryProducts = from P in DBContext.PD_S_PRODUCT
                              /*
                              join PE in DBContext.PD_S_PRODUCT_EXT_AUS on P.PRODUCT_CODE equals PE.PRODUCT_CODE into Ext
                              join PC in DBContext.PD_S_CLASS on P.CLASS_CODE equals PC.CLASS_CODE into Class
                              join PSC in DBContext.PD_S_SUBCLASS on new { P.COMPANY_CODE, P.DIVISION_CODE, P.CLASS_CODE, P.SUBCLASS_CODE } equals new { PSC.COMPANY_CODE, PSC.DIVISION_CODE, PSC.CLASS_CODE, PSC.SUBCLASS_CODE } into SubClass
                              join PG in DBContext.PD_S_GROUP on P.GROUP_CODE  equals PG.GROUP_CODE into Group
                              join PW in DBContext.PD_S_PRODUCT_WARRANTIES_EXT_AUS on P.PRODUCT_CODE  equals PW.PRODUCT_CODE into Warranty
                              join PL in DBContext.PD_S_PRODUCT_PRICELIST on P.PRODUCT_CODE equals PL.PRODUCT_CODE into PriceList
                              join PB in DBContext.PD_S_BAND on P.BAND_CODE equals PB.BAND_CODE into Band
                              join PS in DBContext.PD_S_SUPPLIER on P.SUPPLIER_CODE equals PS.SUPPLIER_CODE into Supplier
                              */
                              join PE in DBContext.PD_S_PRODUCT_EXT_AUS on new { P.COMPANY_CODE, P.DIVISION_CODE, P.PRODUCT_CODE } equals new { PE.COMPANY_CODE, PE.DIVISION_CODE, PE.PRODUCT_CODE } into Ext
                              join PC in DBContext.PD_S_CLASS on new { P.COMPANY_CODE, P.DIVISION_CODE, P.CLASS_CODE } equals new { PC.COMPANY_CODE, PC.DIVISION_CODE, PC.CLASS_CODE } into Class
                              join PSC in DBContext.PD_S_SUBCLASS on new { P.COMPANY_CODE, P.DIVISION_CODE, P.CLASS_CODE, P.SUBCLASS_CODE } equals new { PSC.COMPANY_CODE, PSC.DIVISION_CODE, PSC.CLASS_CODE, PSC.SUBCLASS_CODE } into SubClass
                              join PG in DBContext.PD_S_GROUP on new { P.COMPANY_CODE, P.DIVISION_CODE, P.GROUP_CODE } equals new { PG.COMPANY_CODE, PG.DIVISION_CODE, PG.GROUP_CODE } into Group
                              join PW in DBContext.PD_S_PRODUCT_WARRANTIES_EXT_AUS on new { P.COMPANY_CODE, P.DIVISION_CODE, P.PRODUCT_CODE} equals new { PW.COMPANY_CODE, PW.DIVISION_CODE, PW.PRODUCT_CODE } into Warranty
                              join PL in DBContext.PD_S_PRODUCT_PRICELIST on new { P.COMPANY_CODE, P.DIVISION_CODE, P.PRODUCT_CODE } equals new { PL.COMPANY_CODE, PL.DIVISION_CODE, PL.PRODUCT_CODE } into PriceList
                              join PB in DBContext.PD_S_BAND on new { P.COMPANY_CODE, P.DIVISION_CODE, P.BAND_CODE } equals new { PB.COMPANY_CODE, PB.DIVISION_CODE, PB.BAND_CODE} into Band
                              join PS in DBContext.PD_S_SUPPLIER on new { P.COMPANY_CODE, P.DIVISION_CODE, P.SUPPLIER_CODE } equals new { PS.COMPANY_CODE, PS.DIVISION_CODE, PS.SUPPLIER_CODE } into Supplier

                              select new ProductDBInfo
                              {
                                  Product = P,
                                  ProductExt = Ext.SingleOrDefault(),
                                  ProductClass = Class.Where(E => E.DT_START.GetValueOrDefault(DateTime.MinValue) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.MaxValue) <= DateTime.Today).FirstOrDefault(),
                                  ProductSubClass = SubClass.Where(E => E.DT_START.GetValueOrDefault(DateTime.MinValue) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.MaxValue) <= DateTime.Today).FirstOrDefault(),
                                  ProductGroup = Group.Where(E => E.DT_START.GetValueOrDefault(DateTime.MinValue) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.MaxValue) <= DateTime.Today).FirstOrDefault(),
                                  ProductBand = Band.Where(E => E.DT_START.GetValueOrDefault(DateTime.MinValue) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.MaxValue) <= DateTime.Today).FirstOrDefault(),
                                  ProductWarranty = Warranty.OrderByDescending(E => E.DT_EFFECTIVE_FROM).FirstOrDefault(E => E.DT_EFFECTIVE_FROM <= DateTime.Today),
                                  ProductSupplier = Supplier.Where(E => E.DT_START.GetValueOrDefault(DateTime.MinValue) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.MaxValue) <= DateTime.Today).FirstOrDefault(),
                                  ProductPriceList = PriceList.Where(E => E.DT_VALID <= DateTime.Today).OrderByDescending(E => E.DT_VALID)
                              };


            var predicate = PredicateBuilder.New<ProductDBInfo>(true);
            if (!string.IsNullOrWhiteSpace(ProductCodes))
            {
                string[] ProductList = ProductCodes.Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (ProductList.Length > 0)
                    predicate = predicate.And(E => ProductList.Contains(E.Product.PRODUCT_CODE));
            }
            if (!string.IsNullOrWhiteSpace(Description))
                predicate = predicate.And(E => E.Product.PRODUCT_DESCR.Contains(Description));
            if (Level.HasValue)
                predicate = predicate.And(E => E.Product.BAND_CODE == Level.Value.ToString());
            if (!string.IsNullOrWhiteSpace(Style))
                predicate = predicate.And(E => E.Product.SUBCLASS_CODE == Style);
            if (Family.HasValue)
            {
                string PEDescription = Family.Value.GetDescription();
                predicate = predicate.And(E => E.ProductExt != null && E.ProductExt.PRODUCT_COMMER != null && E.ProductExt.PRODUCT_COMMER.StartsWith(PEDescription));
            }
            if (!string.IsNullOrWhiteSpace(SupplierCode))
            {
                string[] SupplierList = SupplierCode.Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (SupplierList.Length > 0)
                    predicate = predicate.And(E => SupplierList.Contains(E.Product.SUPPLIER_CODE));
            }
            if (!string.IsNullOrWhiteSpace(ClassCode))
                predicate = predicate.And(E => E.Product.CLASS_CODE == ClassCode);


            List<ProductListItem> Result = new List<ProductListItem>();
            foreach (ProductDBInfo Item in qryProducts.Where(predicate).Take(Settings.Value.MaxQueryResult))
            {
                ProductListItem ResultItem = new ProductListItem(Item);
                Result.Add(ResultItem);
            }

            return Result;
        }

    }
}
