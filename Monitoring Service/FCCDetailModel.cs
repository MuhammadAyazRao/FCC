using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FCC_SERVICE
{
    public class FormPdf
    {
        public string url { get; set; }
    }
        public class FCCDetailModel
    {
        [JsonProperty("application_number")]
        public string ApplicationNumber { get; set; }

        [JsonProperty("form_version")]
        public string FormVersion { get; set; }

        [JsonIgnore]
        public string FormPdf { get; set; }

        [JsonProperty("application_status")]
        public string ApplicationStatus { get; set; }

        [JsonProperty("application_nickname")]
        public string ApplicationNickname { get; set; }

        [JsonProperty("filing_window")]
        public string FilingWindow { get; set; }

        [JsonProperty("applicant_name")]
        public string ApplicantName { get; set; }

        [JsonProperty("billed_entity_address")]
        public string BilledEntityAddress { get; set; }

        [JsonProperty("billed_entity_city")]
        public string BilledEntityCity { get; set; }

        [JsonProperty("billed_entity_state")]
        public string BilledEntityState { get; set; }

        [JsonProperty("billed_entity_zip_code")]
        public string BilledEntityZipCode { get; set; }

        [JsonProperty("billed_entity_number")]
        public string BilledEntityNumber { get; set; }

        [JsonProperty("fcc_registration_number")]
        public string FccRegistrationNumber { get; set; }

        [JsonProperty("applicant_type")]
        public string ApplicantType { get; set; }

        [JsonProperty("applicant_subtype")]
        public string ApplicantSubtype { get; set; }

        [JsonProperty("contact_name")]
        public string ContactName { get; set; }

        [JsonProperty("contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("total_student_count")]
        public string TotalStudentCount { get; set; }

        [JsonProperty("urban_rural_status")]
        public string UrbanRuralStatus { get; set; }

        [JsonProperty("unmet_student_needs_1")]
        public string UnmetStudentNeeds1 { get; set; }

        [JsonProperty("unmet_student_needs_2")]     
        public string UnmetStudentNeeds2 { get; set; }

        [JsonProperty("unmet_student_needs_3")]
        public string UnmetStudentNeeds3 { get; set; }

        [JsonProperty("unmet_student_needs_4")]
     
        public string UnmetStudentNeeds4 { get; set; }

        [JsonProperty("unmet_student_needs_5")]
        
        public string UnmetStudentNeeds5 { get; set; }

        [JsonProperty("unmet_student_needs_6")]
        
        public string UnmetStudentNeeds6 { get; set; }

        [JsonProperty("unmet_student_needs_7")]
        
        public string UnmetStudentNeeds7 { get; set; }

        [JsonProperty("unmet_student_needs_8")]
        
        public string UnmetStudentNeeds8 { get; set; }

        [JsonProperty("unmet_student_needs_9")]
        
        public string UnmetStudentNeeds9 { get; set; }

        [JsonProperty("unmet_student_needs_10")]
        
        public string UnmetStudentNeeds10 { get; set; }

        [JsonProperty("unmet_student_needs_11")]
        
        public string UnmetStudentNeeds11 { get; set; }

        [JsonProperty("unmet_student_needs_12")]
        
        public string UnmetStudentNeeds12 { get; set; }

        [JsonProperty("total_funding_commitment_request_amount")]
        public string TotalFundingCommitmentRequestAmount { get; set; }

        [JsonProperty("certified_datetime")]
        public DateTimeOffset CertifiedDatetime { get; set; }

        [JsonProperty("window_status")]
        public string WindowStatus { get; set; }

        [JsonProperty("last_updated_datetime")]
        public DateTimeOffset LastUpdatedDatetime { get; set; }
        [Key]
        [JsonProperty("funding_request_number")]
        public string FundingRequestNumber { get; set; }

        [JsonProperty("funding_request_status")]
        public string FundingRequestStatus { get; set; }

        [JsonProperty("funding_request_nickname")]
        public string FundingRequestNickname { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("agreement_contract_type")]
        public string AgreementContractType { get; set; }

        [JsonProperty("service_provider_name")]
        public string ServiceProviderName { get; set; }

        [JsonProperty("service_provider_identification_number")]
        
        public string ServiceProviderIdentificationNumber { get; set; }

        [JsonProperty("service_start_date")]
        public DateTimeOffset ServiceStartDate { get; set; }

        [JsonProperty("service_end_date")]
        public DateTimeOffset ServiceEndDate { get; set; }

        [JsonProperty("invoicing_method")]
        public string InvoicingMethod { get; set; }

        [JsonProperty("new_construction_self_provisioned_network")]
        public string NewConstructionSelfProvisionedNetwork { get; set; }

        [JsonProperty("funding_request_narrative")]
        public string FundingRequestNarrative { get; set; }

        [JsonProperty("frn_recurring_charges")]
        public string FrnRecurringCharges { get; set; }

        [JsonProperty("frn_one_time_charges")]
        public string FrnOneTimeCharges { get; set; }

        [JsonProperty("frn_total_charges")]
        public string FrnTotalCharges { get; set; }

        [JsonProperty("frn_line_id")]
        
        public long FrnLineId { get; set; }

        [JsonProperty("connection_type")]
        public string ConnectionType { get; set; }

        [JsonProperty("bandwidth_download")]
        public string BandwidthDownload { get; set; }

        [JsonProperty("bandwidth_upload")]
        public string BandwidthUpload { get; set; }

        [JsonProperty("firewall_included")]
        public string FirewallIncluded { get; set; }

        [JsonProperty("monthly_recurring_unit_cost")]
        public string MonthlyRecurringUnitCost { get; set; }

        [JsonProperty("monthly_quantity")]
        
        public string MonthlyQuantity { get; set; }

        [JsonProperty("line_id_months_of_service")]
        public string LineIdMonthsOfService { get; set; }

        [JsonProperty("line_total_recurring_costs")]
        public string LineTotalRecurringCosts { get; set; }

        [JsonProperty("one_time_unit_cost")]
        public string OneTimeUnitCost { get; set; }

        [JsonProperty("one_time_unit_quantity")]
        
        public string OneTimeUnitQuantity { get; set; }

        [JsonProperty("line_total_one_time_costs")]
        public string LineTotalOneTimeCosts { get; set; }

        [JsonProperty("line_total_cost")]
        public string LineTotalCost { get; set; }

        [JsonProperty("consulting_firm")]
        public string ConsultingFirm { get; set; }

        [JsonProperty("frn_approved_amount")]
        public string FrnApprovedAmount { get; set; }

        [JsonProperty("invoice_deadline_date")]
        public DateTimeOffset? InvoiceDeadlineDate { get; set; }

        [JsonProperty("service_delivery_date")]
        public DateTimeOffset? ServiceDeliveryDate { get; set; }

        [JsonProperty("obligation_file")]
        
        public string ObligationFile { get; set; }

        [JsonProperty("fcdl_date")]
        public DateTimeOffset? FcdlDate { get; set; }

        [JsonProperty("fcdl_comment_for_frn")]
        public string FcdlCommentForFrn { get; set; }

        [JsonProperty("frn_authorized_disbursement")]
        public string FrnAuthorizedDisbursement { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("product_make")]
        public string ProductMake { get; set; }

        [JsonProperty("product_model")]
        public string ProductModel { get; set; }

        [JsonProperty("billed_entity_zip_code_ext")]
        public string BilledEntityZipCodeExt { get; set; }

        [JsonProperty("selected_members_entity_data")]
        public string SelectedMembersEntityData { get; set; }

        [JsonProperty("total_count_of_selected_members")]
        
        public string TotalCountOfSelectedMembers { get; set; }

        [JsonProperty("recipients_of_service_entity_data")]
        public string RecipientsOfServiceEntityData { get; set; }

        [JsonProperty("frn_total_count_of_recipients_of_service")]
        
        public string FrnTotalCountOfRecipientsOfService { get; set; }

        [NotMapped]       
        public FormPdf form_pdf { get; set; }
       
    }

}
