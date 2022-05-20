using MassTransit;
using SharedClassModels.DataModels;
using System;
using System.Threading.Tasks;

namespace FlightBookingConsumerService.Models
{
    public class Consumer: IConsumer<TblAirlineRegister>
    {
        private readonly AirlineDBContext _dbContext;
        public Consumer(AirlineDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task Consume(ConsumeContext<TblAirlineRegister> context)
        {

            //var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            //var result = await _mediator.Send(command);
            _dbContext.TblAirlineRegisters.Add(context.Message);
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
