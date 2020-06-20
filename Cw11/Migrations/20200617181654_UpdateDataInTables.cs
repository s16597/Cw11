using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11.Migrations
{
    public partial class UpdateDataInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicaments_Prescriptions_IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctorNavigationIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatientNavigationIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdDoctorNavigationIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdPatientNavigationIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.DropColumn(
                name: "IdDoctorNavigationIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IdPatientNavigationIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropColumn(
                name: "IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Doctors",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "DoctorIdDoctor",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "Prescription_Medicaments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicaments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_MedicamentIdMedicament",
                table: "Prescription_Medicaments",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_PrescriptionIdPrescription",
                table: "Prescription_Medicaments",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_MedicamentIdMedicament",
                table: "Prescription_Medicaments",
                column: "MedicamentIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicaments_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicaments",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_MedicamentIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicaments_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_MedicamentIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicaments_PrescriptionIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.DropColumn(
                name: "DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "Prescription_Medicaments");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicaments");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Doctors",
                newName: "email");

            migrationBuilder.AddColumn<int>(
                name: "IdDoctorNavigationIdDoctor",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPatientNavigationIdPatient",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctorNavigationIdDoctor",
                table: "Prescriptions",
                column: "IdDoctorNavigationIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatientNavigationIdPatient",
                table: "Prescriptions",
                column: "IdPatientNavigationIdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments",
                column: "IdMedicamentNavigationIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments",
                column: "IdPrescriptionNavigationIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicaments_Medicaments_IdMedicamentNavigationIdMedicament",
                table: "Prescription_Medicaments",
                column: "IdMedicamentNavigationIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicaments_Prescriptions_IdPrescriptionNavigationIdPrescription",
                table: "Prescription_Medicaments",
                column: "IdPrescriptionNavigationIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctorNavigationIdDoctor",
                table: "Prescriptions",
                column: "IdDoctorNavigationIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatientNavigationIdPatient",
                table: "Prescriptions",
                column: "IdPatientNavigationIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
