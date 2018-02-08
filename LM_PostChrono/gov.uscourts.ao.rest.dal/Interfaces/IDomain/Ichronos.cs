using gov.uscourts.ao.rest.dal.Domain;
using System;
namespace gov.uscourts.ao.rest.dal.Interfaces.IDomain
{
    public interface Ichronos : IDomainObject
    {
        string attempted { get; set; }
        staff author { get; set; }
        string authorCode { get; set; }
        chronosContact[] chronosContacts { get; set; }
        string chronosNotes { get; set; }
        string chronosStatus { get; set; }
        string clientId { get; set; }
        string confidential { get; set; }
        string contactDate { get; set; }
        string contactTime { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string id { get; set; }
        string noncompliance { get; set; }
        string planChange { get; set; }
        string probPts { get; set; }
        string respNoncompliance { get; set; }
        string thirdPartyRisk { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface Istaff
    {
        staff[] subordinates { get; set; }
        staffRelated supervisor { get; set; }
        string supervisorId { get; set; }
    }

    public interface IchronosContact
    {
        chronosContactCode chronosContactCode { get; set; }
        chronosContactCodePK chronosContactCodeId { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        chronosContactPK id { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface IchronosContactCode
    {
        string active { get; set; }
        string alwaysShow { get; set; }
        chronosCategoryCode chronosCategoryCode { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string description { get; set; }
        chronosContactCodePK id { get; set; }
        string probPts { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface IchronosCategoryCode
    {
        string contactCatCd { get; set; }
        contactCategory contactCategory { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string id { get; set; }
        string nationalCode { get; set; }
        short sortValue { get; set; }
        bool sortValueSpecified { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }
    
    public interface IcontactCategory
    {
        string active { get; set; }
        chronosCategoryCode chronosCatCd { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string description { get; set; }
        string id { get; set; }
        short sortValue { get; set; }
        bool sortValueSpecified { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface IchronosContactPK
    {
        string chronos { get; set; }
        string chronosCode { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string probPts { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }


    public interface IchronosContactCodePK
    {
        string chronosCategoryCode { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string probPts { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface IstaffRelated : IstaffBase { }
    public interface IstaffBase
    {
        string alwaysShow { get; set; }
        string atlasLogin { get; set; }
        string atlasPasswd { get; set; }
        string badgeNo { get; set; }
        string beeper { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string email { get; set; }
        string fax { get; set; }
        string firstName { get; set; }
        string id { get; set; }
        string lastName { get; set; }
        location location { get; set; }
        string locCode { get; set; }
        string managerStatus { get; set; }
        string middleName { get; set; }
        string natid { get; set; }
        string phone1 { get; set; }
        string phone2 { get; set; }
        string probOrPreTrial { get; set; }
        string referralAgent { get; set; }
        string staffDesc { get; set; }
        string staffFuncType { get; set; }
        string staffInitials { get; set; }
        staffType staffType { get; set; }
        string staffTypeCd { get; set; }
        string submitBailReportNotification { get; set; }
        string submitDateChgNotification { get; set; }
        string submitDateInitNotification { get; set; }
        string title { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
        string verifFormChgNotification { get; set; }
    }

    public interface Ilocation
    {
        string createdBy { get; set; }
        string createdOn { get; set; }
        string description { get; set; }
        string id { get; set; }
        string officeCode { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }

    public interface IstaffType
    {
        string createdBy { get; set; }
        string createdOn { get; set; }
        string description { get; set; }
        string id { get; set; }
        string updatedBy { get; set; }
        string updatedOn { get; set; }
    }
}
