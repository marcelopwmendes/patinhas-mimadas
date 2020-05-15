using Microsoft.EntityFrameworkCore;
using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess.Interfaces;
using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public class BookingDataAccess : IBookingDataAccess
    {
        public async Task Add(BookingDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Booking.Add(new Booking
                {
                    Id = model.Id,
                    ServiceId = model.ServiceId,
                    Confirmation = model.Confirmation,
                    CustomerId = model.CustomerId,
                    EmployeeId = model.EmployeeId,
                    Date = model.Date
                });
                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task<BookingDataAccessModel> Get(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Booking model = await context.Booking
                    .Where(e => e.Id == id).SingleOrDefaultAsync();

                if (model != null)
                {
                    return new BookingDataAccessModel
                    {
                        Id = model.Id,
                        ServiceId = model.ServiceId,
                        Confirmation = model.Confirmation,
                        CustomerId = model.CustomerId,
                        EmployeeId = model.EmployeeId,
                        Date = model.Date
                    };
                }

                return null;
            };
        }

        public async Task<IList<BookingDataAccessModel>> GetAll()
        {
            using (var context = new PatinhasMimadasContext())
            {
                return await context.Booking
                    .Select(e => new BookingDataAccessModel
                    {
                        Id = e.Id,
                        ServiceId = e.ServiceId,
                        Confirmation = e.Confirmation,
                        CustomerId = e.CustomerId,
                        EmployeeId = e.EmployeeId,
                        Date = e.Date
                    }).ToListAsync().ConfigureAwait(false);
            };
        }

        public async Task Update(BookingDataAccessModel model)
        {
            using (var context = new PatinhasMimadasContext())
            {
                context.Booking
                    .Update(new Booking
                    {
                        Id = model.Id,
                        ServiceId = model.ServiceId,
                        Confirmation = model.Confirmation,
                        CustomerId = model.CustomerId,
                        EmployeeId = model.EmployeeId,
                        Date = model.Date
                    });

                await context.SaveChangesAsync().ConfigureAwait(false);
            };
        }

        public async Task Delete(Guid id)
        {
            using (var context = new PatinhasMimadasContext())
            {
                Booking model = context.Booking.Where(e => e.Id == id).SingleOrDefault();

                if (model != null)
                {
                    context.Booking.Remove(model);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }

            };
        }
    }
}
