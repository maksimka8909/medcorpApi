using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class hospital_DBContext : DbContext
    {
        public hospital_DBContext()
        {
        }

        public hospital_DBContext(DbContextOptions<hospital_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Checkup> Checkups { get; set; }
        public virtual DbSet<CheckupByRecord> CheckupByRecords { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTimeLog> EmployeeTimeLogs { get; set; }
        public virtual DbSet<EmploymentApplication> EmploymentApplications { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<LaborContract> LaborContracts { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PayType> PayTypes { get; set; }
        public virtual DbSet<PayoutJournal> PayoutJournals { get; set; }
        public virtual DbSet<PersonalFile> PersonalFiles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Preparation> Preparations { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ReasonOfDismissal> ReasonOfDismissals { get; set; }
        public virtual DbSet<RecordForExamination> RecordForExaminations { get; set; }
        public virtual DbSet<RecordForInspection> RecordForInspections { get; set; }
        public virtual DbSet<ResignationLetter> ResignationLetters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SupplyOfEquipment> SupplyOfEquipments { get; set; }
        public virtual DbSet<SupplyOfPreparation> SupplyOfPreparations { get; set; }
        public virtual DbSet<SupplySheetOfEquipment> SupplySheetOfEquipments { get; set; }
        public virtual DbSet<SupplySheetOfPreparation> SupplySheetOfPreparations { get; set; }
        public virtual DbSet<TypeOfEqupiment> TypeOfEqupiments { get; set; }
        public virtual DbSet<TypeOfResearch> TypeOfResearches { get; set; }
        public virtual DbSet<TypeOfVacation> TypeOfVacations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VacationApplication> VacationApplications { get; set; }
        public virtual DbSet<Waybill> Waybills { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=194.32.248.98;user id=maxk;password=Maxk123!;persistsecurityinfo=True;database=hospital_DB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Checkup>(entity =>
            {
                entity.HasKey(e => e.IdCheckup)
                    .HasName("PRIMARY");

                entity.ToTable("Checkup");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdPatient, "ID_patient");

                entity.Property(e => e.IdCheckup)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_checkup");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Conclusion)
                    .IsRequired()
                    .HasMaxLength(511)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdPatient)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_patient");

                entity.Property(e => e.PatientComplaints)
                    .IsRequired()
                    .HasMaxLength(511)
                    .HasColumnName("Patient_complaints")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Prescription)
                    .IsRequired()
                    .HasMaxLength(511)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ResultOfPatientCheckup)
                    .IsRequired()
                    .HasMaxLength(511)
                    .HasColumnName("Result_of_patient_checkup")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Checkups)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("Checkup_ibfk_1");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Checkups)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("Checkup_ibfk_2");
            });

            modelBuilder.Entity<CheckupByRecord>(entity =>
            {
                entity.HasKey(e => e.IdCheckup)
                    .HasName("PRIMARY");

                entity.ToTable("CheckupByRecord");

                entity.HasIndex(e => e.IdRecord, "ID_record");

                entity.Property(e => e.IdCheckup)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_checkup");

                entity.Property(e => e.Conclusion)
                    .IsRequired()
                    .HasMaxLength(511)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.PatientComplaints)
                    .IsRequired()
                    .HasMaxLength(511)
                    .HasColumnName("Patient_complaints")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Prescription)
                    .HasMaxLength(511)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ResultOfPatientCheckup)
                    .IsRequired()
                    .HasMaxLength(511)
                    .HasColumnName("Result_of_patient_checkup")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.CheckupByRecords)
                    .HasForeignKey(d => d.IdRecord)
                    .HasConstraintName("CheckupByRecord_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.IdLaborContract, "ID_labor_contract");

                entity.HasIndex(e => e.IdPersonalFile, "ID_personal_file");

                entity.HasIndex(e => e.IdUser, "ID_user");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdLaborContract)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_labor_contract");

                entity.Property(e => e.IdPersonalFile)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_personal_file");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_user");

                entity.Property(e => e.Status).HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdLaborContractNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdLaborContract)
                    .HasConstraintName("Employee_ibfk_1");

                entity.HasOne(d => d.IdPersonalFileNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdPersonalFile)
                    .HasConstraintName("Employee_ibfk_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("Employee_ibfk_3");
            });

            modelBuilder.Entity<EmployeeTimeLog>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("EmployeeTimeLog");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.EndDateOfShift)
                    .HasColumnType("datetime")
                    .HasColumnName("End_date_of_shift");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.StartDateOfShift)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_date_of_shift");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.EmployeeTimeLogs)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("EmployeeTimeLog_ibfk_1");
            });

            modelBuilder.Entity<EmploymentApplication>(entity =>
            {
                entity.HasKey(e => e.IdStatement)
                    .HasName("PRIMARY");

                entity.ToTable("EmploymentApplication");

                entity.HasIndex(e => e.Description, "Description")
                    .IsUnique();

                entity.Property(e => e.IdStatement)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_statement");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.IdEquipment)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdTypeOfEquipment, "ID_type_of_equipment");

                entity.Property(e => e.IdEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_equipment");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdTypeOfEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_equipment");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Number).HasColumnType("int(11)");

                entity.HasOne(d => d.IdTypeOfEquipmentNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.IdTypeOfEquipment)
                    .HasConstraintName("Equipment_ibfk_1");
            });

            modelBuilder.Entity<Examination>(entity =>
            {
                entity.HasKey(e => e.IdExamination)
                    .HasName("PRIMARY");

                entity.ToTable("Examination");

                entity.HasIndex(e => e.IdRecord, "ID_record");

                entity.Property(e => e.IdExamination)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_examination");

                entity.Property(e => e.Conclusion)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.ResultOfExamination)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .HasColumnName("Result_of_examination")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.Examinations)
                    .HasForeignKey(d => d.IdRecord)
                    .HasConstraintName("Examination_ibfk_1");
            });

            modelBuilder.Entity<LaborContract>(entity =>
            {
                entity.HasKey(e => e.IdLaborContract)
                    .HasName("PRIMARY");

                entity.ToTable("LaborContract");

                entity.HasIndex(e => e.IdPost, "ID_post");

                entity.HasIndex(e => e.IdWorkSchedule, "ID_work_schedule");

                entity.Property(e => e.IdLaborContract)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_labor_contract");

                entity.Property(e => e.DateOfBeginingWork)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_begining_work");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdPost)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_post");

                entity.Property(e => e.IdWorkSchedule)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_work_schedule");

                entity.Property(e => e.Rate)
                    .IsRequired()
                    .HasMaxLength(12)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.LaborContracts)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("LaborContract_ibfk_1");

                entity.HasOne(d => d.IdWorkScheduleNavigation)
                    .WithMany(p => p.LaborContracts)
                    .HasForeignKey(d => d.IdWorkSchedule)
                    .HasConstraintName("LaborContract_ibfk_2");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PRIMARY");

                entity.ToTable("Patient");

                entity.HasIndex(e => e.IdUser, "ID_user");

                entity.HasIndex(e => e.Policy, "Policy")
                    .IsUnique();

                entity.HasIndex(e => e.Snils, "SNILS")
                    .IsUnique();

                entity.Property(e => e.IdPatient)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_patient");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.DateOfIssue)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_issue");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_user");

                entity.Property(e => e.IssuedBy)
                    .HasMaxLength(255)
                    .HasColumnName("Issued_by")
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .HasColumnName("Middle_name")
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Passport_number")
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassportSeries)
                    .HasMaxLength(255)
                    .HasColumnName("Passport_series")
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Policy)
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Snils)
                    .IsRequired()
                    .HasColumnName("SNILS")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("Patient_ibfk_1");
            });

            modelBuilder.Entity<PayType>(entity =>
            {
                entity.HasKey(e => e.IdPayType)
                    .HasName("PRIMARY");

                entity.ToTable("PayType");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdPayType)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_pay_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<PayoutJournal>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("PayoutJournal");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdPayType, "ID_pay_type");

                entity.HasIndex(e => e.IdWaybill, "ID_waybill");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdPayType)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_pay_type");

                entity.Property(e => e.IdWaybill)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_waybill");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.PayoutJournals)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("PayoutJournal_ibfk_2");

                entity.HasOne(d => d.IdPayTypeNavigation)
                    .WithMany(p => p.PayoutJournals)
                    .HasForeignKey(d => d.IdPayType)
                    .HasConstraintName("PayoutJournal_ibfk_3");

                entity.HasOne(d => d.IdWaybillNavigation)
                    .WithMany(p => p.PayoutJournals)
                    .HasForeignKey(d => d.IdWaybill)
                    .HasConstraintName("PayoutJournal_ibfk_1");
            });

            modelBuilder.Entity<PersonalFile>(entity =>
            {
                entity.HasKey(e => e.IdPersonalFile)
                    .HasName("PRIMARY");

                entity.ToTable("PersonalFile");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.HasIndex(e => e.IdStatement, "ID_statement");

                entity.HasIndex(e => e.Inn, "INN")
                    .IsUnique();

                entity.HasIndex(e => e.Phonenumber, "Phonenumber")
                    .IsUnique();

                entity.HasIndex(e => e.Snils, "SNILS")
                    .IsUnique();

                entity.Property(e => e.IdPersonalFile)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_personal_file");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasDefaultValueSql("'Не заполнен'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.EmploymentHistory)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Employment_history")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(32)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdStatement)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_statement");

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("INN")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .HasColumnName("Middle_name")
                    .HasDefaultValueSql("'Отсутствует'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MilitaryId)
                    .HasMaxLength(255)
                    .HasColumnName("Military_ID")
                    .HasDefaultValueSql("'Не заполнен'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Passport_number")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassportSeries)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Passport_series")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Requisites)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Snils)
                    .IsRequired()
                    .HasColumnName("SNILS")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdStatementNavigation)
                    .WithMany(p => p.PersonalFiles)
                    .HasForeignKey(d => d.IdStatement)
                    .HasConstraintName("PersonalFile_ibfk_1");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PRIMARY");

                entity.ToTable("Post");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdPost)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_post");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Salary).HasPrecision(13, 2);
            });

            modelBuilder.Entity<Preparation>(entity =>
            {
                entity.HasKey(e => e.IdPreparation)
                    .HasName("PRIMARY");

                entity.ToTable("Preparation");

                entity.HasIndex(e => e.IdProvider, "ID_provider");

                entity.Property(e => e.IdPreparation)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_preparation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdProvider)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_provider");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Preparations)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("Preparation_ibfk_1");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PRIMARY");

                entity.ToTable("Provider");

                entity.HasIndex(e => e.Inn, "INN")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdProvider)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_provider");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("INN")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ReasonOfDismissal>(entity =>
            {
                entity.HasKey(e => e.IdReasonOfDismissal)
                    .HasName("PRIMARY");

                entity.ToTable("ReasonOfDismissal");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdReasonOfDismissal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_reason_of_dismissal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<RecordForExamination>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("RecordForExamination");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdPatient, "ID_patient");

                entity.HasIndex(e => e.IdTypeOfResearch, "ID_type_of_research");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateOfUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdPatient)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_patient");

                entity.Property(e => e.IdTypeOfResearch)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_research");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.RecordForExaminations)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("RecordForExamination_ibfk_1");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.RecordForExaminations)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("RecordForExamination_ibfk_2");

                entity.HasOne(d => d.IdTypeOfResearchNavigation)
                    .WithMany(p => p.RecordForExaminations)
                    .HasForeignKey(d => d.IdTypeOfResearch)
                    .HasConstraintName("RecordForExamination_ibfk_3");
            });

            modelBuilder.Entity<RecordForInspection>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("RecordForInspection");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdPatient, "ID_patient");

                entity.Property(e => e.IdRecord)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_record");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateOfUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdPatient)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_patient");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.RecordForInspections)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("RecordForInspection_ibfk_1");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.RecordForInspections)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("RecordForInspection_ibfk_2");
            });

            modelBuilder.Entity<ResignationLetter>(entity =>
            {
                entity.HasKey(e => e.IdResignationLetter)
                    .HasName("PRIMARY");

                entity.ToTable("ResignationLetter");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdReasonOfDismissal, "ID_reason_of_dismissal");

                entity.Property(e => e.IdResignationLetter)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_resignation_letter");

                entity.Property(e => e.DateOfDismissal)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_dismissal");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdReasonOfDismissal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_reason_of_dismissal");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.ResignationLetters)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("ResignationLetter_ibfk_2");

                entity.HasOne(d => d.IdReasonOfDismissalNavigation)
                    .WithMany(p => p.ResignationLetters)
                    .HasForeignKey(d => d.IdReasonOfDismissal)
                    .HasConstraintName("ResignationLetter_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("Role");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(61)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<SupplyOfEquipment>(entity =>
            {
                entity.HasKey(e => e.IdSupply)
                    .HasName("PRIMARY");

                entity.ToTable("SupplyOfEquipment");

                entity.HasIndex(e => e.IdEquipment, "ID_equipment");

                entity.Property(e => e.IdSupply)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_supply");

                entity.Property(e => e.IdEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_equipment");

                entity.Property(e => e.Number)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.SupplyOfEquipments)
                    .HasForeignKey(d => d.IdEquipment)
                    .HasConstraintName("SupplyOfEquipment_ibfk_1");
            });

            modelBuilder.Entity<SupplyOfPreparation>(entity =>
            {
                entity.HasKey(e => e.IdSupply)
                    .HasName("PRIMARY");

                entity.ToTable("SupplyOfPreparation");

                entity.HasIndex(e => e.IdPreparation, "ID_preparation");

                entity.Property(e => e.IdSupply)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_supply");

                entity.Property(e => e.IdPreparation)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_preparation");

                entity.Property(e => e.Number)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdPreparationNavigation)
                    .WithMany(p => p.SupplyOfPreparations)
                    .HasForeignKey(d => d.IdPreparation)
                    .HasConstraintName("SupplyOfPreparation_ibfk_1");
            });

            modelBuilder.Entity<SupplySheetOfEquipment>(entity =>
            {
                entity.HasKey(e => e.IdSheet)
                    .HasName("PRIMARY");

                entity.ToTable("SupplySheetOfEquipment");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdProvider, "ID_provider");

                entity.HasIndex(e => e.IdSupply, "ID_supply");

                entity.Property(e => e.IdSheet)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_sheet");

                entity.Property(e => e.DateOfSupply)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_supply");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdProvider)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_provider");

                entity.Property(e => e.IdSupply)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_supply");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.SupplySheetOfEquipments)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("SupplySheetOfEquipment_ibfk_1");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.SupplySheetOfEquipments)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("SupplySheetOfEquipment_ibfk_3");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany(p => p.SupplySheetOfEquipments)
                    .HasForeignKey(d => d.IdSupply)
                    .HasConstraintName("SupplySheetOfEquipment_ibfk_2");
            });

            modelBuilder.Entity<SupplySheetOfPreparation>(entity =>
            {
                entity.HasKey(e => e.IdSheet)
                    .HasName("PRIMARY");

                entity.ToTable("SupplySheetOfPreparation");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdProvider, "ID_provider");

                entity.HasIndex(e => e.IdSupply, "ID_supply");

                entity.Property(e => e.IdSheet)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_sheet");

                entity.Property(e => e.DateOfSupply)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_supply");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdProvider)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_provider");

                entity.Property(e => e.IdSupply)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_supply");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.SupplySheetOfPreparations)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("SupplySheetOfPreparation_ibfk_1");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.SupplySheetOfPreparations)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("SupplySheetOfPreparation_ibfk_3");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany(p => p.SupplySheetOfPreparations)
                    .HasForeignKey(d => d.IdSupply)
                    .HasConstraintName("SupplySheetOfPreparation_ibfk_2");
            });

            modelBuilder.Entity<TypeOfEqupiment>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfEquipment)
                    .HasName("PRIMARY");

                entity.ToTable("TypeOfEqupiment");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdTypeOfEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_equipment");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TypeOfResearch>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfResearch)
                    .HasName("PRIMARY");

                entity.ToTable("TypeOfResearch");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdTypeOfResearch)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_research");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TypeOfVacation>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfVacation)
                    .HasName("PRIMARY");

                entity.ToTable("TypeOfVacation");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdTypeOfVacation)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_vacation");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("User");

                entity.HasIndex(e => e.IdRole, "ID_role");

                entity.HasIndex(e => e.Login, "Login")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_user");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_role");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(61)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(127)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Status).HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("User_ibfk_1");
            });

            modelBuilder.Entity<VacationApplication>(entity =>
            {
                entity.HasKey(e => e.IdVacationApplication)
                    .HasName("PRIMARY");

                entity.ToTable("VacationApplication");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.HasIndex(e => e.IdTypeOfVacation, "ID_type_of_vacation");

                entity.Property(e => e.IdVacationApplication)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_vacation_application");

                entity.Property(e => e.BeginingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Begining_date");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ending_date");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.Property(e => e.IdTypeOfVacation)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_type_of_vacation");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.VacationApplications)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("VacationApplication_ibfk_1");

                entity.HasOne(d => d.IdTypeOfVacationNavigation)
                    .WithMany(p => p.VacationApplications)
                    .HasForeignKey(d => d.IdTypeOfVacation)
                    .HasConstraintName("VacationApplication_ibfk_2");
            });

            modelBuilder.Entity<Waybill>(entity =>
            {
                entity.HasKey(e => e.IdWaybill)
                    .HasName("PRIMARY");

                entity.ToTable("Waybill");

                entity.HasIndex(e => e.IdEmployee, "ID_employee");

                entity.Property(e => e.IdWaybill)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_waybill");

                entity.Property(e => e.Amount).HasPrecision(13, 2);

                entity.Property(e => e.DateOfEnrollment)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_enrollment");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_employee");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Waybills)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("Waybill_ibfk_1");
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.HasKey(e => e.IdWorkSchedule)
                    .HasName("PRIMARY");

                entity.ToTable("WorkSchedule");

                entity.HasIndex(e => e.Name, "Name")
                    .IsUnique();

                entity.Property(e => e.IdWorkSchedule)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_work_schedule");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TypeOfWorkSchedule)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Type_of_work_schedule")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
