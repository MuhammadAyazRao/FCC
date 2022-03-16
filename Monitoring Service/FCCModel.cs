using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FCC_SERVICE
{
    

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FCCModel
    {
       
        //public string a_application_number { get; set; }
        //public string a_form_version { get; set; }
        //public string a_application_status { get; set; }
        //public string a_filing_window { get; set; }
        //public string a_applicant_name { get; set; }
        //public string a_billed_entity_number { get; set; }
        //public string a_billed_entity_city { get; set; }
        //public string a_billed_entity_state { get; set; }
        //public string a_applicant_type { get; set; }
        //public string a_contact_name { get; set; }
        //public string a_contact_phone { get; set; }
        //public string a_contact_email { get; set; }
        //public string a_consulting_firm { get; set; }
        //public DateTime a_certified_datetime { get; set; }
        //public string a_window_status { get; set; }
        //[Key]
        //public string a_funding_request_number { get; set; }
        //public string a_funding_request_status { get; set; }
        //public string a_service_type { get; set; }
        //public string a_service_provider_name { get; set; }
        //public string a_service_provider_identification_number { get; set; }
        //public string a_invoicing_method { get; set; }
        //public DateTime a_invoice_deadline_date { get; set; }
        //public string a_obligation_file { get; set; }
        //public DateTime a_fcdl_date { get; set; }
        //public string a_fcdl_comment_for_frn { get; set; }
        //public string a_frn_total_charges { get; set; }
        //public string a_frn_approved_amount { get; set; }
        //public string a_frn_authorized_disbursement { get; set; }
        //public DateTime a_last_updated_datetime { get; set; }




        [JsonProperty("a_application_number")]
        public string AApplicationNumber { get; set; }

        [JsonProperty("a_form_version")]
        public string AFormVersion { get; set; }

        [JsonProperty("a_application_status")]
        public string AApplicationStatus { get; set; }

        [JsonProperty("a_filing_window")]
        public string AFilingWindow { get; set; }

        [JsonProperty("a_applicant_name")]
        public string AApplicantName { get; set; }

        [JsonProperty("a_billed_entity_number")]
        public string ABilledEntityNumber { get; set; }

        [JsonProperty("a_billed_entity_city")]
        public string ABilledEntityCity { get; set; }

        [JsonProperty("a_billed_entity_state")]
        public string ABilledEntityState { get; set; }

        [JsonProperty("a_applicant_type")]
        public string AApplicantType { get; set; }

        [JsonProperty("a_contact_name")]
        public string AContactName { get; set; }

        [JsonProperty("a_contact_phone")]
        public string AContactPhone { get; set; }

        [JsonProperty("a_contact_email")]
        public string AContactEmail { get; set; }

        [JsonProperty("a_consulting_firm")]
        public string AConsultingFirm { get; set; }

        [JsonProperty("a_certified_datetime")]
        public DateTime? ACertifiedDatetime { get; set; }

        [JsonProperty("a_window_status")]
        public string AWindowStatus { get; set; }

        [Key]
        [JsonProperty("a_funding_request_number")]
        public string AFundingRequestNumber { get; set; }

        [JsonProperty("a_funding_request_status")]
        public string AFundingRequestStatus { get; set; }

        [JsonProperty("a_service_type")]
        public string AServiceType { get; set; }

        [JsonProperty("a_service_provider_name")]
        public string AServiceProviderName { get; set; }

        [JsonProperty("a_service_provider_identification_number")]
   
        public string AServiceProviderIdentificationNumber { get; set; }

        [JsonProperty("a_invoicing_method")]
        public string AInvoicingMethod { get; set; }

        [JsonProperty("a_invoice_deadline_date")]
        public DateTime? AInvoiceDeadlineDate { get; set; }

        [JsonProperty("a_obligation_file")]
        public string AObligationFile { get; set; }

        [JsonProperty("a_fcdl_date")]
        public DateTime? AFcdlDate { get; set; }

        [JsonProperty("a_fcdl_comment_for_frn")]
        public string AFcdlCommentForFrn { get; set; }

        [JsonProperty("a_frn_total_charges")]
        public string AFrnTotalCharges { get; set; }

        [JsonProperty("a_frn_approved_amount")]
        public string AFrnApprovedAmount { get; set; }

        [JsonProperty("a_frn_authorized_disbursement")]
        public string AFrnAuthorizedDisbursement { get; set; }

        [JsonProperty("a_last_updated_datetime")]
        public DateTimeOffset ALastUpdatedDatetime { get; set; }

    }

    public class RecordsCount
    {
        public string count { get; set; }
    }



}
