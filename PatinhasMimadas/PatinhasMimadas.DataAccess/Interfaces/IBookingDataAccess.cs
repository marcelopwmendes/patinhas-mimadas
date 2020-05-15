using PatinhasMimadas.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess.Interfaces
{
    public interface IBookingDataAccess
    {
        Task<BookingDataAccessModel> Get(Guid id);
        Task<IList<BookingDataAccessModel>> GetAll();
        Task Add(BookingDataAccessModel model);
        Task Update(BookingDataAccessModel model);
        Task Delete(Guid id);
    }
}
