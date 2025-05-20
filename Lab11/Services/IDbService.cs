using Lab11.DTOs;
using Lab11.Models;

namespace Lab11.Services;

public interface IDbService
{
    Task<Prescription> CreatePrescriptionAsync(CreatePrescriptionDto prescriptionDto);
    Task<GetPatientDetailsDto> GetPatientDetailsAsync(int id);
}