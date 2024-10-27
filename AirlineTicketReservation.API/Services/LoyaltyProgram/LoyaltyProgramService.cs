using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.API.Repositories.LoyaltyProgramRepository;
using System.Data;

namespace AirlineTicketReservation.API.Services.LoyaltyProgram {
    public class LoyaltyProgramService : ILoyaltyProgramService {

        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly IPassengerRepository _passengerRepository;
        public LoyaltyProgramService(ILoyaltyProgramRepository loyaltyProgramRepository, IPassengerRepository _p) {
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _passengerRepository = _p;

        }

        public async Task<ResponseModel<LoyaltyProgramEntity>> createLoyaltyProgram(LoyaltyProgramEntity loyaltyProgram) {

            var response = new ResponseModel<LoyaltyProgramEntity>();

            try {
                var entity = await _loyaltyProgramRepository.findByPassengerId(loyaltyProgram.Id);

                // Verificar se o passageiro já tem um loyaltyProgram
                if (entity != null) {
                    throw new Exception();
                }

                await _loyaltyProgramRepository.create(loyaltyProgram);

                var loyaltyPrograms = await _loyaltyProgramRepository.GetAll();

                response.Results.AddRange(loyaltyPrograms);
                response.Messages.Add("LoyaltyProgram created with sucess.");

                return response;

            } catch (Exception ex) {
                throw;
            }
        }
    }
}
