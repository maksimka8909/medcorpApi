using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Checkups = new HashSet<Checkup>();
            EmployeeTimeLogs = new HashSet<EmployeeTimeLog>();
            PayoutJournals = new HashSet<PayoutJournal>();
            RecordForExaminations = new HashSet<RecordForExamination>();
            RecordForInspections = new HashSet<RecordForInspection>();
            ResignationLetters = new HashSet<ResignationLetter>();
            SupplySheetOfEquipments = new HashSet<SupplySheetOfEquipment>();
            SupplySheetOfPreparations = new HashSet<SupplySheetOfPreparation>();
            VacationApplications = new HashSet<VacationApplication>();
            Waybills = new HashSet<Waybill>();
        }

        public int IdEmployee { get; set; }
        public int? IdLaborContract { get; set; }
        public int? IdPersonalFile { get; set; }
        public bool? Status { get; set; }
        public int? IdUser { get; set; }

        public virtual LaborContract IdLaborContractNavigation { get; set; }
        public virtual PersonalFile IdPersonalFileNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Checkup> Checkups { get; set; }
        public virtual ICollection<EmployeeTimeLog> EmployeeTimeLogs { get; set; }
        public virtual ICollection<PayoutJournal> PayoutJournals { get; set; }
        public virtual ICollection<RecordForExamination> RecordForExaminations { get; set; }
        public virtual ICollection<RecordForInspection> RecordForInspections { get; set; }
        public virtual ICollection<ResignationLetter> ResignationLetters { get; set; }
        public virtual ICollection<SupplySheetOfEquipment> SupplySheetOfEquipments { get; set; }
        public virtual ICollection<SupplySheetOfPreparation> SupplySheetOfPreparations { get; set; }
        public virtual ICollection<VacationApplication> VacationApplications { get; set; }
        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}
